/* int n = 10;
int[] scores = new int[n];
scores[0] = 1;
scores[1] = 2;
scores[2] = 3;
scores[3] = 4;
scores[4] = 5;

Console.Write("Scores: ");
for (int i = 0; i < scores.Length; i++)
{
    Console.Write(scores[i] + " ");
}

*/

/*

Console.Write("Input number of items: ");
int n = Int32.Parse(Console.ReadLine());
int[] scores = new int[n];

for (int i = 0; i < scores.Length; i++)
{
    Console.Write($"Input scores[{i}]: ");
    scores[i] = Int32.Parse(Console.ReadLine());
}

Console.Write("Scores: ");
for (int i = 0; i < scores.Length; i++)
{
    Console.Write(scores[i] + " ");
}

*/

int[,] multiplicationTableOf3 = new int[11, 3];

for (int i = 1; i <= 10; i++)
{
    multiplicationTableOf3[i, 0] = 3;
    multiplicationTableOf3[i, 1] = i;
    multiplicationTableOf3[i, 2] = 3 * i;
}

Console.WriteLine("The multiplication of 3: ");
for (int i = 1; i <= 10; i++)
{
    Console.WriteLine($"{multiplicationTableOf3[i, 0]} x {multiplicationTableOf3[i, 1]} = {multiplicationTableOf3[i, 2]}");
}


