using System.Diagnostics;

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

        static long _mrgCmps = 0;

        static void MergeSort(int[] arr, int left, int right, bool showTrace = false)
        {
            if (left >= right) return;              // base case: 1 element

            int mid = left + (right - left) / 2;   // avoids integer overflow
            MergeSort(arr, left, mid);
            MergeSort(arr, mid + 1, right);
            Merge(arr, left, mid, right, showTrace);
        }

        static void Merge(int[] arr, int left, int mid, int right, bool showTrace)
        {
            // Copy both halves into temporary arrays
            int[] L = arr[left..(mid + 1)];         // C# range syntax
            int[] R = arr[(mid + 1)..(right + 1)];

            int i = 0, j = 0, k = left;

            while (i < L.Length && j < R.Length)
            {
                _mrgCmps++;
                if (L[i] <= R[j]) arr[k++] = L[i++];  // <= keeps sort stable
                else arr[k++] = R[j++];
            }
            while (i < L.Length) arr[k++] = L[i++];   // copy remaining L
            while (j < R.Length) arr[k++] = R[j++];   // copy remaining R

            if (showTrace)
                Print($"Merged [{left}..{right}]", arr);
        }


        static long _qCmps = 0;

        static void QuickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                int pi = Partition(arr, low, high);
                QuickSort(arr, low, pi - 1);    // sort left of pivot
                QuickSort(arr, pi + 1, high);   // sort right of pivot
            }
        }

        static int Partition(int[] arr, int low, int high)
        {
            int pivot = arr[high];   // Lomuto: last element as pivot
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                _qCmps++;
                if (arr[j] <= pivot)
                {
                    i++;
                    Swap(arr, i, j);
                }
            }
            Swap(arr, i + 1, high);   // place pivot in its final position
            return i + 1;
        }


        // Measure one sorting algorithm: run several times on fresh copies, return the median time
        static double Measure(Action<int[]> sort, int[] source, int runs = 3)
        {
            var times = new List<double>();
            for (int r = 0; r < runs; r++)
            {
                int[] a = Copy(source);                 // every run starts from the same original data
                var sw = Stopwatch.StartNew();
                sort(a);
                sw.Stop();

                if (!IsSorted(a))
                    throw new Exception("Sorting algorithm produced an incorrect result!");
                times.Add(sw.Elapsed.TotalMilliseconds);
            }
            times.Sort();
            return times[times.Count / 2];              // median is less sensitive to noise than the mean
        }



        public static void Main(string[] args)
        {
            int n = 1000000;

            // Create the original random data (values from 1 to 99999)
            int[] data = Random(n, seed: 42, max: 100000);
            Console.WriteLine($"Number of elements: {n}\n");

            Stopwatch sw = new Stopwatch();
            int[] arr;



            // ----- Merge Sort -----
            arr = Copy(data);
            sw.Restart();
            MergeSort(arr, 0, arr.Length - 1);
            sw.Stop();
            Console.WriteLine($"Merge Sort     : {sw.Elapsed.TotalMilliseconds} ms");

            // ----- Quick Sort -----
            arr = Copy(data);
            sw.Restart();
            QuickSort(arr, 0, arr.Length - 1);
            sw.Stop();
            Console.WriteLine($"Quick Sort     : {sw.Elapsed.TotalMilliseconds} ms");

            // ----- Bubble Sort -----
            arr = Copy(data);                  // sort a copy, keep the original data unchanged
            sw.Restart();
            BubbleSort(arr);
            sw.Stop();
            Console.WriteLine($"Bubble Sort    : {sw.Elapsed.TotalMilliseconds} ms");

            // ----- Selection Sort -----
            arr = Copy(data);
            sw.Restart();
            SelectionSort(arr);
            sw.Stop();
            Console.WriteLine($"Selection Sort : {sw.Elapsed.TotalMilliseconds} ms");

            // ----- Insertion Sort -----
            arr = Copy(data);
            sw.Restart();
            InsertionSort(arr);
            sw.Stop();
            Console.WriteLine($"Insertion Sort : {sw.Elapsed.TotalMilliseconds} ms");
        }
    }
}
