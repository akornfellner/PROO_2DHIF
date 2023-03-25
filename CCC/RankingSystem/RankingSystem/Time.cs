/// <summary>
/// Represents a time in the format of HH:MM:SS
/// </summary>
public class Time : IComparable<Time>
{
    public int Hour { get; set; }
    public int Minute { get; set; }
    public int Second { get; set; }

    public Time(string input)
    {
        string[] time = input.Split(':');
        Hour = int.Parse(time[0]);
        Minute = int.Parse(time[1]);
        Second = int.Parse(time[2]);
    }

    /// <summary>
    /// Converts the time to seconds
    /// </summary>
    public int ToSeconds()
    {
        return Hour * 3600 + Minute * 60 + Second;
    }

    public int CompareTo(Time? other)
    {
        return ToSeconds().CompareTo(other?.ToSeconds());
    }

    public override string ToString()
    {
        return $"{Hour}:{Minute}:{Second}";
    }
}