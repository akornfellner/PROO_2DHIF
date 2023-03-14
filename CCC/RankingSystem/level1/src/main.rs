use std::env;
use time::Time;

mod time;

fn main() {
    let args: Vec<String> = env::args().collect();
    let input = args[1].clone();

    let times: Vec<&str> = input.split(' ').collect();

    println!(
        "{}",
        Time::new(times[0]).diff(&Time::new(times[1])).to_string()
    );
}
