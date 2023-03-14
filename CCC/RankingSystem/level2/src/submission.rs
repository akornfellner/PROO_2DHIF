use crate::time::Time;

#[derive(Debug, Clone)]
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
