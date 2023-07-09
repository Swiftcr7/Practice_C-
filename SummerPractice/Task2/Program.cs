namespace Task2
{
    class Program
    {

        private static IEnumerable<primer> GetCollection()
        {
            yield return new primer(2);
            
            yield return new primer(2);
            ;
            yield return new primer(3);
            ;
            yield return new primer(3);
            ;
            yield return new primer(4);
            ;
            yield return new primer(5);
            ;

        }

        static void Main(string[] args)
        {
            var a = new List<primer>()
            {
                new primer(1), new primer(2), new primer(3), 
               
            };

            var x = Extensions.All_possible_combinations(a, MyComparer.Instance).ToList();
            foreach (var item in x)
            {
                foreach (var i in item)
                {
                    Console.Write($"size:{i.Size},");
                }
                Console.Write(Environment.NewLine);
            }
            Console.WriteLine("-------all_possible_subsets----------");

            var y = a.all_possible_subsets(MyComparer.Instance).ToList();
            foreach (var item in y)
            {
                foreach (var i in item)
                {
                    Console.Write($"size:{i.Size},");
                }
                Console.Write(Environment.NewLine);
            }
            
            Console.WriteLine("-------generating_combinations----------");

            var z = a.generating_combinations(2, MyComparer.Instance).ToList();
            foreach (var item in z)
            {
                foreach (var i in item)
                {
                    Console.Write($"size:{i.Size},");
                }
                Console.Write(Environment.NewLine);
            }



        }



    }
        
}