use std::fs;

fn main() {
    for i in 1..=6 {
        let input = fs::read_to_string(&(String::from("input/input") + &i.to_string()))
            .expect("Something went wrong reading the file");
        let values: Vec<i32> = input
            .split_whitespace()
            .map(|s| s.parse().unwrap())
            .collect();

        let n = values[0] as usize;

        let numbers = values[1..].to_vec();

        let mut max = 0;

        let mut i = 0usize;

        let mut sum = 0;

        while i < n {
            sum += numbers[i];

            if sum < 0 {
                sum = 0;
            }

            if sum > max {
                max = sum;
            }

            i += 1;
        }
        println!("{max}");
    }
}
