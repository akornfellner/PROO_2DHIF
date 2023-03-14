use std::env;
use submission::Submission;
use time::Time;

mod submission;
mod time;

fn main() {
    let args: Vec<String> = env::args().collect();
    let input = args[1].clone();

    let parts = input.split(' ').collect::<Vec<&str>>();

    let start = Time::new(parts[0]);
    let mut submissions: Vec<Submission> = vec![];

    for i in (2..parts.len()).step_by(3) {
        let id: u32 = parts[i].parse().unwrap();
        let time = Time::new(parts[i + 1]);
        let correct = parts[i + 2] == "correct";

        submissions.push(Submission::new(id, time, correct));
    }

    let mut first: Submission = submissions[0].clone();
    let mut min = u32::MAX;

    for submission in submissions {
        if submission.correct {
            let diff = start.diff(&submission.time);

            if diff < min {
                min = diff;
                first = submission.clone();
            }
        }
    }

    println!("{} {}", first.id, first.time)
}
