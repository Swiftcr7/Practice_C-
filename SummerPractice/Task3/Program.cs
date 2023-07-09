using System.Collections;


namespace Task3
{
    class Program
    {
        private static int com(int x, int y)
        {
            return Math.Abs(x).CompareTo(Math.Abs(y));
        }

        static void Main(string[] args)
        {
            var a = new[] { 1, 2, 7, 4, 9, 3, 10, 5, 6, 8 };
            var array = new [] { 7, 0, -4, 3, 1, -2, 5 };
            Console.WriteLine("------------Decreasing, Merging, comparator");
            var array1 = a.MySort(ExtensionsSort.Method.Decreasing, ExtensionsSort.Algorithm.Merging).ToArray();
            foreach (var item in array1)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("------------Increasing, Inserts, ");

                var array2=array.MySort(ExtensionsSort.Method.Increasing, ExtensionsSort.Algorithm.Inserts).ToArray();
                foreach (var item in array2)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("------------Increasing, Pyramidal, comparer");
            
                var array3=array.MySort(ExtensionsSort.Method.Increasing, ExtensionsSort.Algorithm.Pyramidal, Comparer<int>.Create(new Comparison<int>(com)));
                foreach (var item in array3)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("------------Decreasing, Choice, comparison");
            
                var array4=array.MySort(ExtensionsSort.Method.Decreasing, ExtensionsSort.Algorithm.Choice, new Comparison<int>(com));
                foreach (var item in array4)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("------------Increasing, Merging, comparison");

                var array5 = array.MySort(ExtensionsSort.Method.Increasing, ExtensionsSort.Algorithm.Merging,
                    new Comparison<int>(com));
                foreach (var item in array5)
                {
                    Console.WriteLine(item);
                }
        }
    }
}
