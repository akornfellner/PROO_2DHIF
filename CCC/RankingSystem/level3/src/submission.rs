use crate::time::Time;

#[derive(Debug, Clone, Eq, PartialEq)]
pub struct Submission {
    pub id: u32,
    pub time: Time,
    pub correct: bool,
}

impl Submission {
    pub fn new(id: u32, time: Time, correct: bool) -> Submission {
        Submission { id, time, correct }
    }
}

impl PartialOrd for Submission {
    fn partial_cmp(&self, other: &Self) -> Option<std::cmp::Ordering> {
        Some(self.cmp(other))
    }
}

impl Ord for Submission {
    fn cmp(&self, other: &Self) -> std::cmp::Ordering {
        self.time.cmp(&other.time)
    }
}
