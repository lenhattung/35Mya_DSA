/*
Dictionary<string, int> scores = new Dictionary<string, int>();

// - Add: throws if key exists
scores.Add("Alice", 92);
scores.Add("Bob", 85);
scores.Add("Oo", 100);
scores.Add("Paing", 80);
scores.TryAdd("Paing", 90);

foreach (var key in scores.Keys)
{
    Console.WriteLine($"{key} : {scores[key]}");
}

// ── Read by key: throws KeyNotFoundException if missing ──
Console.WriteLine($"Alice: {scores["Alice"]}");

// ── TryGetValue: safe read ───────────────────────────────
if (scores.TryGetValue("Eve", out int eveScore))
    Console.WriteLine($"Eve: {eveScore}");
else
    Console.WriteLine("Eve not found");

// ── ContainsKey ──────────────────────────────────────────
Console.WriteLine($"ContainsKey Bob: {scores.ContainsKey("Bob")}"); //
Console.WriteLine($"ContainsKey Zara: {scores.ContainsKey("Zara")}"); //

// ── Remove ───────────────────────────────────────────────
scores.Remove("Charlie");
Console.WriteLine($"After Remove(Charlie) — Count: {scores.Count}");

// ── Remove and retrieve at once ──────────────────────────
if (scores.Remove("Bob", out int bobScore))
    Console.WriteLine($"Removed Bob, his score was {bobScore}");


// ── Print all entries ─────────────────────────────────────
Console.WriteLine("Remaining entries:");
foreach (KeyValuePair<string, int> kv in scores)
    Console.WriteLine($" {kv.Key,-12} -> {kv.Value}");


//--- 
var inventory = new Dictionary<string, int>
{
    ["apple"] = 50,
    ["banana"] = 30,
    ["cherry"] = 120,
    ["date"] = 15,
    ["elderberry"] = 8,
};
// ── Iterate over KeyValuePairs ────────────────────────────
Console.WriteLine("All inventory:");
foreach (var (item, qty) in inventory) // deconstruct KeyValuePair
    Console.WriteLine($" {item,-12} : {qty,4} units");


// ── Iterate over Keys only ───────────────────────────────
Console.Write("Items: ");
foreach (string item in inventory.Keys)
    Console.Write(item + " ");
Console.WriteLine();


// ── Iterate over Values only ─────────────────────────────
int total = 0;
foreach (int qty in inventory.Values) total += qty;
Console.WriteLine($"Total units in stock: {total}");

// ── GetValueOrDefault: safe access without try-catch ─────
int mangos = inventory.GetValueOrDefault("mango", 0);
int apples = inventory.GetValueOrDefault("apple", 0);
Console.WriteLine($"mango stock: {mangos} apple stock: {apples}");

// ── Convert Keys/Values to List for sorting ───────────────
var sortedKeys = new List<string>(inventory.Keys);
sortedKeys.Sort();
Console.WriteLine("Sorted alphabetically:");
foreach (string k in sortedKeys)
    Console.WriteLine($" {k,-12} : {inventory[k]}");

// ── Find items with low stock (< 20 units) ────────────────
Console.WriteLine("Low stock alerts:");
foreach (var (item, qty) in inventory)
    if (qty < 20) Console.WriteLine($" ⚠ {item}: only {qty} left");
*/

string text = "the quick brown fox jumps over the lazy dog the fox";
string[] words = text.Split(' ');

Dictionary<string, int> freq = new Dictionary<string, int>();

foreach (string word in words)
{
    // Pattern: GetValueOrDefault then update
    freq[word] = freq.GetValueOrDefault(word, 0) + 1;
}
// ── Print frequency table ────────────────────────────────
Console.WriteLine($"Total words: {words.Length} Unique: {freq.Count}");
Console.WriteLine("\nWord frequencies:");
foreach (var (word, count) in freq)
    Console.WriteLine($" {word,-10} : {count}");

// ── Find the most frequent word ──────────────────────────
string topWord = "";
int topCount = 0;
foreach (var (word, count) in freq)
    if (count > topCount) { topWord = word; topCount = count; }
Console.WriteLine($"\nMost frequent: {topWord} ({topCount} times)");
// ── Show only words appearing more than once ─────────────
Console.WriteLine("\nDuplicated words:");
foreach (var (word, count) in freq)
    if (count > 1) Console.WriteLine($" {word}: {count}x");
