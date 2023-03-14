use std::env;
use submission::Submission;
use time::Time;

mod submission;
mod time;

fn main() {
    let args: Vec<String> = env::args().collect();
    let input = args[1].clone();

    let parts = input.split(' ').collect::<Vec<&str>>();
    let task_id: u32 = parts[1].parse().unwrap();

    let mut submissions: Vec<Submission> = vec![];

    for i in (3..parts.len()).step_by(4) {
        let id: u32 = parts[i].parse().unwrap();
        let time = Time::new(parts[i + 1]);
        let correct = parts[i + 2] == "correct";
        let task = parts[i + 3].parse().unwrap();

        if task_id == task && correct {
            submissions.push(Submission::new(id, time, correct, task));
        }
    }

    submissions.sort();

    let mut output = String::new();

    for submission in &submissions {
        output += format!("{} ", submission.id).as_str();
        output += format!("{} ", submission.time).as_str();
    }

    output = output.trim().to_string();

    println!("{} {}", submissions.len(), output);
}
