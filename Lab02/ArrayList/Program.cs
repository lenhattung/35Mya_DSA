using System.Collections;

int[] arr = new int[100];

ArrayList list = new ArrayList();

// Can store different types (but should not!)
list.Add(42); // int
list.Add("Hello"); // string
list.Add(3.14); // double PI
list.Add(true); // bool

Console.WriteLine(list.Count);

// Must cast when reading — easy source of runtime errors!
int num = (int)list[0];
string str = (string)list[1];
Console.WriteLine($"[0] = {num},  [1] = {str}");

// Practical ArrayList: store same type so Sort() works
ArrayList scores = new ArrayList { 55, 72, 88, 61, 94, 45 };
scores.Sort();
Console.Write("After Sort(): ");
foreach (int i in scores)
{
    Console.Write(i + " ");
}
Console.WriteLine();

scores.Reverse();
Console.Write("After Sort(): ");
foreach (int i in scores)
{
    Console.Write(i + " ");
}
Console.WriteLine();