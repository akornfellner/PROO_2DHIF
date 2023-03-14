use std::fs;

fn main() {
    for i in 1..=6 {
        let input = fs::read_to_string(&(String::from("input/input") + &i.to_string()))
            .expect("Something went wrong reading the file");
        let values: Vec<i32> = input
            .split_whitespace()
            .map(|s| s.parse().unwrap())
            .collect();

        let start = values[1] as usize;
        let end = values[2] as usize;

        let numbers = values[3..].to_vec();

        let mut sum = 0;

        for n in start..=end {
            sum += numbers[n - 1];
        }
        println!("{sum}");
    }
}
