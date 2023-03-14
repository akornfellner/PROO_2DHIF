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
        let mut count = 0;
        let mut indexes = String::new();

        for i in 0..n {
            let mut sum = 0;

            for (j, number) in numbers.iter().enumerate().take(n).skip(i) {
                sum += number;

                if sum < 0 {
                    break;
                }

                if sum > max {
                    max = sum;
                    count = 0;
                    indexes = String::new();
                }

                if sum == max {
                    count += 1;
                    indexes += &format!("{} {} ", i + 1, j + 1);
                }
            }
        }
        indexes = indexes.trim().to_string();

        println!("{max} {count} {indexes}");
    }
}
