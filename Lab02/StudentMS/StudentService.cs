namespace StudentManager;

public class StudentService
{
    // ── Student list stored in List<T> ─────────────────────
    private List<Student> _students = new List<Student>();


    // ── 1. Add student ─────────────────────────────────────
    public void Add(Student s)
    {
        // Check for duplicate ID
        if (_students.Exists(x => x.Id == s.Id))
        {
            Console.WriteLine($"  ✖  ID {s.Id} already exists!");
            return;
        }
        _students.Add(s);
        Console.WriteLine($"  ✔  Added: {s.Name}");
    }

    // ── 2. Display all ────────────────────────────────────
    public void DisplayAll()
    {
        if (_students.Count == 0)
        {
            Console.WriteLine("  (List is empty)");
            return;
        }
        Console.WriteLine($"  {"ID",-12} {"Full Name",-20} {"Score",5}  Grade        Major");
        Console.WriteLine("  " + new string('-', 68));
        _students.ForEach(s => Console.WriteLine("  " + s));
        Console.WriteLine($"  Total: {_students.Count} student(s)");
    }

    // ── 3. Search by name ──────────────────────────────────
    public void SearchByName(string keyword)
    {
        // FindAll + lowercase keyword for case-insensitive search
        List<Student> found = _students.FindAll(
            s => s.Name.ToLower().Contains(keyword.ToLower()));

        if (found.Count == 0)
            Console.WriteLine($"  No student found with keyword: '{keyword}'");
        else
        {
            Console.WriteLine($"  Found {found.Count} result(s):");
            found.ForEach(s => Console.WriteLine("  " + s));
        }
    }

    // ── 4. Highest / lowest scoring student ────────────────
    public void ShowMinMax()
    {
        if (_students.Count == 0) { Console.WriteLine("  (Empty)"); return; }

        // Use ForEach to find min/max
        Student max = _students[0];
        Student min = _students[0];
        _students.ForEach(s =>
        {
            if (s.Score > max.Score) max = s;
            if (s.Score < min.Score) min = s;
        });
        Console.WriteLine($"  🏆 Highest: {max}");
        Console.WriteLine($"  📉 Lowest: {min}");
    }

    // ── 5. Sort ─────────────────────────────────────────────
    public void Sort(string by)
    {
        if (by == "name")
            _students.Sort((a, b) => a.Name.CompareTo(b.Name));
        else  // by score descending
            _students.Sort((a, b) => b.Score.CompareTo(a.Score));

        Console.WriteLine($"  ✔  Sorted by {(by == "name" ? "name" : "score")}");
        DisplayAll();
    }

    // ── 6. Delete by ID ─────────────────────────────────────
    public void DeleteById(string id)
    {
        // Use RemoveAll with a lambda
        int count = _students.RemoveAll(s => s.Id == id);
        if (count > 0) Console.WriteLine($"  ✔  Deleted student ID: {id}");
        else Console.WriteLine($"  ✖  ID not found: {id}");
    }

    // ── 7. Filter by score range ─────────────────────────
    public void FilterByScore(double min, double max)
    {
        List<Student> result = _students.FindAll(
            s => s.Score >= min && s.Score <= max);

        Console.WriteLine($"  Students in score range [{min} – {max}] ({result.Count} result(s)):");
        if (result.Count == 0) Console.WriteLine("  (None)");
        else result.ForEach(s => Console.WriteLine("  " + s));
    }

    // ── 8. Statistics ────────────────────────────────────
    public void Statistics()
    {
        if (_students.Count == 0) { Console.WriteLine("  (Empty)"); return; }

        double sum = 0;
        _students.ForEach(s => sum += s.Score);
        double avg = sum / _students.Count;

        int pass = _students.FindAll(s => s.Score >= 5.0).Count;
        int fail = _students.Count - pass;

        Console.WriteLine($"  Total students  : {_students.Count}");
        Console.WriteLine($"  Average score   : {avg:F2}");
        Console.WriteLine($"  Pass (>= 5.0)   : {pass}");
        Console.WriteLine($"  Fail (< 5.0)    : {fail}");

        // Count by grade using FindAll
        Console.WriteLine("  Classification:");
        foreach (string g in new[] { "Excellent", "Very Good", "Good", "Average", "Weak" })
        {
            int cnt = _students.FindAll(s => s.Grade == g).Count;
            if (cnt > 0) Console.WriteLine($"    {g,-12}: {cnt}");
        }
    }
}
