use std::{collections::HashMap, fs};
use submission::Submission;
use time::Time;
use user::User;

mod submission;
mod time;
mod user;

fn main() {
    let input = fs::read_to_string("input").unwrap();

    let parts = input.split(' ').collect::<Vec<&str>>();
    let x: u32 = parts[1].parse().unwrap();

    let mut submissions: Vec<Submission> = vec![];

    for i in (3..parts.len()).step_by(4) {
        let id: u32 = parts[i].parse().unwrap();
        let time = Time::new(parts[i + 1]);
        let correct = parts[i + 2] == "correct";
        let task = parts[i + 3].parse().unwrap();

        submissions.push(Submission::new(id, time, correct, task));
    }

    submissions.sort();

    let mut tasks: HashMap<u32, u32> = HashMap::new();
    let mut users: HashMap<u32, User> = HashMap::new();

    for submission in submissions {
        if submission.correct {
            let entry = tasks.entry(submission.task).or_insert(0);
            let user = users
                .entry(submission.id)
                .or_insert(User::new(submission.id));

            user.points += x - *entry;
            *entry += 1;
        } else {
            users
                .entry(submission.id)
                .or_insert(User::new(submission.id));
        }
    }

    let mut users: Vec<User> = users.into_values().collect();

    users.sort();

    let mut output = String::new();

    for user in users {
        output += &format!("{} {} ", user.points, user.id);
    }

    output = output.trim().to_string();

    println!("{output}");
}
