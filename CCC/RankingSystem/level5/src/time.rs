use std::fmt::Display;

#[derive(Debug, Clone, Eq, PartialEq)]
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
}

impl PartialOrd for Time {
    fn partial_cmp(&self, other: &Self) -> Option<std::cmp::Ordering> {
        Some(self.cmp(other))
    }
}

impl Display for Time {
    fn fmt(&self, f: &mut std::fmt::Formatter<'_>) -> std::fmt::Result {
        write!(f, "{:02}:{:02}:{:02}", self.hour, self.minute, self.second)
    }
}

impl Ord for Time {
    fn cmp(&self, other: &Self) -> std::cmp::Ordering {
        self.to_seconds().cmp(&other.to_seconds())
    }
}
