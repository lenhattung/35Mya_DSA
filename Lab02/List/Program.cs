// Create a List and add elements
List<int> scores = new List<int>();

scores.Add(85);
scores.Add(92);
scores.Add(78);
scores.Add(95);
scores.Add(88);

Console.WriteLine($"Element count: {scores.Count}");
Console.WriteLine($"Capacity:   {scores.Capacity}");   // always >= Count

// - Print the list
Console.Write("List: ");
foreach (int e in scores)
{
    Console.Write(e + " ");
}
Console.WriteLine();

// - Access by index
Console.WriteLine($"Element [0]: {scores[0]}");
Console.WriteLine($"Element [1]: {scores[1]}");



//==================================================
List<string> fruits = new List<string> { "Apple", "Banana", "Cherry", "Date", "Elderberry" };
fruits.ForEach(x => Console.WriteLine(x));

// ── Insert at a specific position ───────────────────────
fruits.Insert(2, "Blueberry");
Console.WriteLine("After Insert(2, Blueberry):");
fruits.ForEach(e => Console.Write(e + " "));
Console.WriteLine();

// ── Remove by value 
fruits.Remove("Date");
Console.WriteLine("After Remove Date:");
fruits.ForEach(e => Console.Write(e + " "));
Console.WriteLine();

// ── RemoveAt theo index ──────────────────────────────────
fruits.RemoveAt(0);
Console.WriteLine("\nAfter RemoveAt(0):");
fruits.ForEach(f => Console.Write(f + "  "));
Console.WriteLine();

// ── RemoveAll by condition ────────────────────────────────
int removed = fruits.RemoveAll(e => e.Length > 6); // remove names longer than 6 chars
Console.WriteLine($"\nAfter RemoveAll (Length > 6) — removed {removed} element(s):");
fruits.ForEach(f => Console.Write(f + "  "));
Console.WriteLine();


// ===============
List<string> names = new List<string> { "Charlie", "Alice", "Bob", "Dave", "Eve" };

// ── Default sort (alphabetical) ─────────────────────────
names.ForEach(n => Console.Write(n + "  "));
Console.WriteLine();

names.Sort();
Console.Write("Sort(): ");
names.ForEach(n => Console.Write(n + "  "));
Console.WriteLine();

// ── Reverse ─────────────────────────────────────────────
names.Reverse();
Console.Write("Reverse(): ");
names.ForEach(n => Console.Write(n + "  "));
Console.WriteLine();

// ── Sort with Comparison — by name length ───────────────
names.Sort((a, b) => b.Length.CompareTo(a.Length));
Console.Write("Sort by length: ");
names.ForEach(n => Console.Write(n + "  "));
Console.WriteLine();

// ── Sort complex objects ─────────────────────────────────
var students = new List<(string Name, int Score)>
{
    ("An",   85), ("Binh", 92), ("Chi",  78),
    ("Dung", 92), ("Em",   65)
};


students.ForEach(s => Console.WriteLine($"  {s.Name,-10} {s.Score}"));


// Sort: highest score first; same score → alphabetical by name
students.Sort((a, b) =>
{
    int cmp = b.Score.CompareTo(a.Score); // descending by score
    if (cmp == 0) // a.Score == b.score
    {
        cmp = a.Name.CompareTo(b.Name); // ascending by name
    }
    return cmp;
});


// ======== GetRange, AddRange, ToArray, CopyTo

List<int> data = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

// ── GetRange: extract a sub-list ────────────────────────
List<int> mid = data.GetRange(3, 4);   // from index 3, take 4 elements
Console.Write("GetRange(3, 4): ");
mid.ForEach(n => Console.Write(n + "  "));   // 4 5 6 7
Console.WriteLine();

// ── AddRange: add multiple elements ──────────────────────
List<int> extra = new List<int> { 11, 12, 13 };
data.AddRange(extra);
Console.WriteLine($"After AddRange: Count = {data.Count}");

// ── ToArray ─────────────────────────────────────────────
int[] arr = data.ToArray();
Console.WriteLine($"ToArray()[0] = {arr[0]},  arr.Length = {arr.Length}");

// ── CopyTo ──────────────────────────────────────────────
int[] dest = new int[5];
data.CopyTo(2, dest, 0, 5);  // copy 5 elements from index 2 into dest
Console.Write("CopyTo (5 elements from index 2): ");
foreach (int x in dest) Console.Write(x + "  ");
Console.WriteLine();

Console.WriteLine("\nScore board (high → low):");
students.ForEach(s => Console.WriteLine($"  {s.Name,-10} {s.Score}"));
