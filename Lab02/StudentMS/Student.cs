namespace StudentManager;

public class Student
{
    public string Id { get; set; }
    public string Name { get; set; }
    public double Score { get; set; }
    public string Major { get; set; }

    public Student(string id, string name, double score, string major)
    {
        Id = id;
        Name = name;
        Score = score;
        Major = major;
    }

    // Academic grade classification
    public string Grade => Score switch
    {
        >= 9.0 => "Excellent",
        >= 8.0 => "Very Good",
        >= 7.0 => "Good",
        >= 5.0 => "Average",
        _ => "Weak",
    };

    public override string ToString()
        => $"{Id,-12} {Name,-20} {Score,5:F1}  [{Grade}]  {Major}";
}
