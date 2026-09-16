HashSet<string> tags = new HashSet<string>();

tags.Add("csharp");
tags.Add("dotnet");
tags.Add("csharp");
tags.Add("algorithm");
tags.Add("dotnet");

Console.WriteLine($"Count: {tags.Count}");

Console.WriteLine($"Contains(csharp): {tags.Contains("csharp")}");
Console.WriteLine($"Contains(csharp): {tags.Contains("python")}");

foreach (string tag in tags)
{
    Console.WriteLine(tag);
}

// ── Remove ───────────────────────────────────────────────
bool removed = tags.Remove("dotnet");
Console.WriteLine($"Remove(dotnet): {removed} | Count now: {tags.Count}");


// ── Add items from array quickly ─────────────────────────
string[] newTags = { "csharp", "oop", "generics", "linq" };
foreach (string t in newTags) tags.Add(t); // "csharp" duplicate ignored
Console.WriteLine($"After adding array — Count: {tags.Count}");

// ── CopyTo / ToList ──────────────────────────
// ── CopyTo / ToList ──────────────────────────────────────
string[] arr = new string[tags.Count];
tags.CopyTo(arr);
Console.WriteLine($"CopyTo: {string.Join(", ", arr)}");


HashSet<int> A = new HashSet<int> { 1, 2, 3, 4, 5 };
HashSet<int> B = new HashSet<int> { 3, 4, 5, 6, 7 };

static void Print(string label, HashSet<int> s)
{
    var sorted = new List<int>(s);
    sorted.Sort();
    Console.WriteLine($" {label,-28}: {{ {string.Join(", ", sorted)} }}");
}

// ── Union: A ∪ B ─────────────────────────────────────────
var union = new HashSet<int>(A);
union.UnionWith(B);
Print("A ∪ B (Union)", union);

// ── Intersection: A ∩ B ──────────────────────────────────
var intersect = new HashSet<int>(A);
intersect.IntersectWith(B);
Print("A ∩ B (Intersection)", intersect);

// ── Difference: A − B ────────────────────────────────────
var diffAB = new HashSet<int>(A);
diffAB.ExceptWith(B);
Print("A − B (Difference)", diffAB);

// ── Symmetric Difference: A △ B ─────────────────────────
var symDiff = new HashSet<int>(A);
symDiff.SymmetricExceptWith(B);


Print("A △ B (Symmetric Diff)", symDiff);
// ── Subset / Superset ────────────────────────────────────

var sub = new HashSet<int> { 3, 4 };
Console.WriteLine($" {{3,4}} IsSubsetOf A : {sub.IsSubsetOf(A)}"); // true
Console.WriteLine($" A IsSupersetOf {{3,4}}: {A.IsSupersetOf(sub)}"); // true
Console.WriteLine($" A Overlaps B : {A.Overlaps(B)}"); // true
Console.WriteLine($" A SetEquals B : {A.SetEquals(B)}"); //false
Console.WriteLine($" A SetEquals A copy : {A.SetEquals(new HashSet<int>(A))}"); // True


/// ----
// SortedSet (remember in Python, Java - TreeSet)
SortedSet<string> tags_2 = new SortedSet<string>();

tags_2.Add("python");
tags_2.Add("csharp");
tags_2.Add("algorithm");
tags_2.Add("oop");
tags_2.Add("donet");



foreach (var tag in tags_2)
{
    Console.Write(tag + ", ");
}


SortedSet<int> scores = new SortedSet<int> { 88, 45, 72, 88, 95, 60, 72, 100 };
// Duplicates 88 and 72 are ignored automatically
Console.WriteLine($"Count: {scores.Count}"); // 6, not 8
Console.Write("Sorted set: ");
foreach (int s in scores) Console.Write(s + " ");
Console.WriteLine();

// ── Min / Max (O(log n)) ─────────────────────────────────
Console.WriteLine($"Min: {scores.Min} Max: {scores.Max}");

// ── GetViewBetween: range query ──────────────────────────
SortedSet<int> range = scores.GetViewBetween(60, 90);
Console.Write("Scores in [60, 90]: ");
foreach (int s in range) Console.Write(s + " ");
Console.WriteLine();

// ── Reverse iteration ────────────────────────────────────
Console.Write("Descending: ");
foreach (int s in scores.Reverse()) Console.Write(s + " ");
Console.WriteLine();

// ── SortedSet<string>: strings sorted alphabetically ─────
SortedSet<string> words = new SortedSet<string> { "banana", "apple", "cherry", "apple", "date", "banana" };
Console.WriteLine($"Unique words sorted: {string.Join(", ", words)}");

// ── Set operations work the same as HashSet ──────────────
SortedSet<int> other = new SortedSet<int> { 70, 88, 95, 110 };
scores.IntersectWith(other);
Console.Write("After IntersectWith {70,88,95,110}: ");
foreach (int s in scores) Console.Write(s + " ");
Console.WriteLine();
