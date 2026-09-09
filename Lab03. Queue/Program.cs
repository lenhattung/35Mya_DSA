using Lab03._Queue;

Queue<string> names = new Queue<string>();

// -- Enqueue: add items to the Back ----
names.Enqueue("Aung");
names.Enqueue("Htet"); // The
names.Enqueue("Htwe"); // Three
names.Enqueue("Kyaw"); // Chieu
names.Enqueue("Latt");
names.Enqueue("Naw");
names.Enqueue("Oo");
names.Enqueue("Paing");
names.Enqueue("Satt");
names.Enqueue("Sithu");
names.Enqueue("Thet");
names.Enqueue("Thu");
names.Enqueue("Win");

Console.WriteLine($"Count: {names.Count}");
Console.WriteLine($"Peek (front, not rmoved): {names.Peek()}");

// - Print all (foreach does NOT remove items) 
Console.WriteLine();
Console.WriteLine("Queue (front -> back): ");
foreach (string name in names)
{
    Console.Write(name + " -> ");
}
Console.WriteLine();

// Dequeue: remove from the FRONT
Console.WriteLine($"Dequeue: " + names.Dequeue());
Console.WriteLine($"Dequeue: " + names.Dequeue());
Console.WriteLine();
Console.WriteLine("Queue (front -> back): ");
foreach (string name in names)
{
    Console.Write(name + " -> ");
}
Console.WriteLine();


// ==================

Queue<int> q = new Queue<int>();
int[] seed = { 10, 20, 30, 40, 50 };
foreach (int n in seed) q.Enqueue(n);

// ── Contains ────────────────────────────────────────────
Console.WriteLine($"Contains(30): {q.Contains(30)}");   // True
Console.WriteLine($"Contains(99): {q.Contains(99)}");   // False


// ── ToArray: snapshot, does NOT dequeue ─────────────────
int[] snap = q.ToArray();
Console.Write("ToArray: ");
foreach (int n in snap) Console.Write(n + "  ");
Console.WriteLine($"  | Queue still has {q.Count} items");

// ── CopyTo: copy into an existing array from index 1 ────
int[] dest = new int[7];
q.CopyTo(dest, 1);    // leaves dest[0] = 0
Console.Write("CopyTo (offset 1): ");
foreach (int n in dest) Console.Write(n + "  ");
Console.WriteLine();

// ── Clear ───────────────────────────────────────────────
q.Clear();
Console.WriteLine($"After Clear — Count: {q.Count}");

// ── Exception handling ───────────────────────────────────
try
{
    q.Dequeue();
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}

// ====================
var sys = new TicketSystem();
sys.Submit("Paing", "Can not login to school website");
sys.Submit("Oo", "Can not submit tution fee");
sys.Submit("Htet", "Email not working");

Console.WriteLine();
sys.ShowQueue();
sys.ShowNext();

Console.WriteLine();
sys.ProcessNext();
sys.ProcessNext();

Console.WriteLine();
sys.ShowQueue();

sys.Submit("Diana", "Password reset");
sys.ShowQueue();
