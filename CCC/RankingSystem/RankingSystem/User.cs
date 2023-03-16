public class User : IComparable<User>
{
    public int Id { get; set; }
    public int Points { get; set; }

    public User(int id, int points)
    {
        Id = id;
        Points = points;
    }

    public int CompareTo(User? other)
    {
        int value = Points.CompareTo(other?.Points);

        if (value == 0)
        {
            return Id.CompareTo(other?.Id);
        }

        return -value;
    }
}