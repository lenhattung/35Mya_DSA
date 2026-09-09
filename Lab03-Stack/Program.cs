using Lab03_Stack;

Stack<string> stack = new Stack<string>();

// Stack: LIFO - Last in First Out
// - Push : add items to the TOP

stack.Push("Alice");
stack.Push("Bob");
stack.Push("Charlie");
stack.Push("Diana");

Console.WriteLine($"Count: {stack.Count}");
Console.WriteLine($"Peek (top, not removed): {stack.Peek()}");

// ── Print all (foreach iterates top → bottom) ───────────
Console.Write("Stack (top → bottom): ");
foreach (string name in stack)
    Console.Write(name + "  ");
Console.WriteLine();

// ── Pop: remove from the TOP ────────────────────────────
Console.WriteLine($"Pop: {stack.Pop()}");
Console.WriteLine($"Pop: {stack.Pop()}");

Console.WriteLine($"Count after 2 pops: {stack.Count}");
Console.Write("Remaining (top → bottom): ");
foreach (string name in stack)
    Console.Write(name + "  ");
Console.WriteLine();

// ── TryPop: safe removal ─────────────────────────────────
while (stack.TryPop(out string person))
    Console.WriteLine($"Popped: {person}");

Console.WriteLine($"Empty? {stack.Count == 0}");


// ── Test the editor ──────────────────────────────────────
var ed = new TextEditor();
ed.Type("Hello");
ed.Type(", World");
ed.Type("!");
ed.Status();
ed.Undo();
ed.Undo();
ed.Status();
ed.Redo();
ed.Type(" C#");   // new type clears redo
ed.Redo();        // nothing to redo
ed.Status();
