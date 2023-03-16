public class Submission : IComparable<Submission>
{
    public int Id { get; set; }
    public Time Time { get; set; }
    public bool Correct { get; set; }
    public int TaskId { get; set; }

    public Submission(int id, string time, bool correct, int taskId)
    {
        Id = id;
        Time = new Time(time);
        Correct = correct;
        TaskId = taskId;
    }

    public override string ToString()
    {
        return $"Id: {Id}, Time: {Time}, Correct: {Correct}, TaskId: {TaskId}";
    }

    public int CompareTo(Submission? other)
    {
        return Time.CompareTo(other?.Time);
    }
}