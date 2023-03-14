use std::fs;

fn main() {
    for i in 1..=5 {
        let filename = String::from("input/input") + &i.to_string();
        let (n, m, prices, weights, mut cars) = get_inputs(&filename);

        let mut spaces: Vec<i32> = vec![0; n as usize];
        let mut amount = 0;
        let mut count = 0;
        let mut waiting: Vec<i32> = vec![];

        let mut car = 0;

        while !cars.is_empty() {
            if count == n {
                while cars[0] > 0 {
                    waiting.push(cars.remove(0));
                }
                car = cars.remove(0);
            } else {
                if !waiting.is_empty() {
                    car = waiting.remove(0);
                } else {
                    car = cars.remove(0);
                }
            }

            if car > 0 {
                let index = find_free(&spaces);
                spaces[index] = car;
                count += 1;
            } else {
                if waiting.contains(&-car) {
                    waiting.remove(find_car(&waiting, -car));
                    continue;
                }

                let index = find_car(&spaces, -car);
                spaces[index] = 0;
                amount += prices[index] * mult(weights[(-car - 1) as usize]);
                count -= 1;
            }
        }

        println!("{}", amount);
    }
}

fn get_inputs(filename: &str) -> (i32, i32, Vec<i32>, Vec<i32>, Vec<i32>) {
    let input: String = fs::read_to_string(filename).unwrap();
    let lines: Vec<&str> = input.lines().collect();
    let first: Vec<&str> = lines[0].split(" ").collect();
    let n = first[0].parse::<i32>().unwrap();
    let m = first[1].parse::<i32>().unwrap();

    let prices: Vec<i32> = lines[1]
        .split(" ")
        .map(|x| x.parse::<i32>().unwrap())
        .collect();
    let weights: Vec<i32> = lines[2]
        .split(" ")
        .map(|x| x.parse::<i32>().unwrap())
        .collect();
    let cars: Vec<i32> = lines[3]
        .split(" ")
        .map(|x| x.parse::<i32>().unwrap())
        .collect();

    (n, m, prices, weights, cars)
}

fn find_free(spaces: &[i32]) -> usize {
    for i in 0..spaces.len() {
        if spaces[i] == 0 {
            return i;
        }
    }

    return usize::MAX;
}

fn find_car(spaces: &[i32], number: i32) -> usize {
    for i in 0..spaces.len() {
        if spaces[i] == number {
            return i;
        }
    }

    return usize::MAX;
}

fn mult(n: i32) -> i32 {
    return (n as f32 / 100.0).ceil() as i32;
}
