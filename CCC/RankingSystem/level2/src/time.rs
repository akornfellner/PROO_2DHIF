use std::fmt::Display;

#[derive(Debug, Clone)]
pub struct Time {
    hour: u8,
    minute: u8,
    second: u8,
}

impl Time {
    pub fn new(line: &str) -> Time {
        let time: Vec<&str> = line.split(':').collect();

        let hour = time[0].parse::<u8>().unwrap();
        let minute = time[1].parse::<u8>().unwrap();
        let second = time[2].parse::<u8>().unwrap();

        Time {
            hour,
            minute,
            second,
        }
    }

    fn to_seconds(&self) -> u32 {
        let hour = self.hour as u32 * 3600;
        let minute = self.minute as u32 * 60;
        let second = self.second as u32;

        hour + minute + second
    }

    pub fn diff(&self, other: &Self) -> u32 {
        let self_seconds = self.to_seconds();
        let other_seconds = other.to_seconds();

        other_seconds - self_seconds
    }
}

impl Display for Time {
    fn fmt(&self, f: &mut std::fmt::Formatter<'_>) -> std::fmt::Result {
        write!(f, "{:02}:{:02}:{:02}", self.hour, self.minute, self.second)
    }
}
