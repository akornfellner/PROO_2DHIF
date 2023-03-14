#[derive(Debug, PartialEq, Eq)]
pub struct User {
    pub id: u32,
    pub points: u32,
}

impl User {
    pub fn new(id: u32) -> User {
        User { id, points: 0 }
    }
}

impl PartialOrd for User {
    fn partial_cmp(&self, other: &Self) -> Option<std::cmp::Ordering> {
        Some(self.cmp(other))
    }
}

impl Ord for User {
    fn cmp(&self, other: &Self) -> std::cmp::Ordering {
        let ordering = self.points.cmp(&other.points);
        if ordering == std::cmp::Ordering::Equal {
            self.id.cmp(&other.id)
        } else {
            ordering.reverse()
        }
    }
}
