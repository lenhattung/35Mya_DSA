namespace Lab05_Sorting
{
    internal class ArrayHelper
    {

        public static void Print(string label, int[] arr)
            => Console.WriteLine($"  {label,-22}: [ {string.Join(", ", arr)} ]");

        public static void Swap(int[] arr, int i, int j)
            => (arr[i], arr[j]) = (arr[j], arr[i]);

        public static int[] Copy(int[] arr) => (int[])arr.Clone();

        public static int[] Random(int n, int seed = 42, int max = 100)
        {
            var rnd = new System.Random(seed);
            return Enumerable.Range(0, n).Select(_ => rnd.Next(1, max)).ToArray();
        }

        public static bool IsSorted(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
                if (arr[i] > arr[i + 1]) return false;
            return true;
        }

        public static (int cmps, int swaps) BubbleSort(int[] arr, bool showTrace = false)
        {
            int n = arr.Length, cmps = 0, swaps = 0;

            for (int i = 0; i < n - 1; i++)
            {
                bool swapped = false;

                for (int j = 0; j < n - i - 1; j++)   // shrink right boundary each pass
                {
                    cmps++;
                    if (arr[j] > arr[j + 1])
                    {
                        Swap(arr, j, j + 1);
                        swaps++;
                        swapped = true;
                    }
                }

                if (showTrace)
                    Print($"Pass {i + 1}", arr);

                if (!swapped) break;    // already sorted — no need for more passes
            }
            return (cmps, swaps);
        }

        static (int cmps, int swaps) SelectionSort(int[] arr, bool showTrace = false)
        {
            int n = arr.Length, cmps = 0, swaps = 0;

            for (int i = 0; i < n - 1; i++)
            {
                int minIdx = i;

                for (int j = i + 1; j < n; j++)    // find minimum in unsorted region
                {
                    cmps++;
                    if (arr[j] < arr[minIdx]) minIdx = j;
                }

                if (minIdx != i)                    // swap only if needed
                {
                    Swap(arr, i, minIdx);
                    swaps++;
                }

                if (showTrace)
                    Print($"Pass {i + 1} (min={arr[i]})", arr);
            }
            return (cmps, swaps);
        }

        static (int cmps, int shifts) InsertionSort(int[] arr, bool showTrace = false)
        {
            int n = arr.Length, cmps = 0, shifts = 0;

            for (int i = 1; i < n; i++)
            {
                int key = arr[i];   // element to be placed
                int j = i - 1;

                // Shift elements greater than key one position to the right
                while (j >= 0 && arr[j] > key)
                {
                    cmps++;
                    arr[j + 1] = arr[j];   // shift — NOT a swap
                    shifts++;
                    j--;
                }
                if (j >= 0) cmps++;        // the final failed comparison

                arr[j + 1] = key;          // place key in correct position

                if (showTrace)
                    Print($"i={i} key={key}", arr);
            }
            return (cmps, shifts);
        }

        public static void Main(string[] args)
        {
            // Test
            int[] data = { 64, 34, 25, 12, 22 };
            ArrayHelper.Print("Input", data);

            var (c, s) = ArrayHelper.InsertionSort(data, showTrace: true);

            ArrayHelper.Print("Sorted", data);
            Console.WriteLine($"  Comparisons: {c}   Swaps: {s}");
            Console.WriteLine($"  Is sorted? {ArrayHelper.IsSorted(data)}");
        }
    }
}
