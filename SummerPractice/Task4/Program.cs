namespace Task4
{
    class Program
    {
        public static double f(double x)
        {
            return x * x * x + 1;
        }
        static void Main(string[] args)
        {
            var array = new IDefiniteIntegral[]
            {
                new SimpsonIntegrate(), new TrapezoidIntegrate(), new CentralRectanglesIntegrate(),
                new LeftRectanglesIntegrate(), new RightRectanglesIntegrate()
            };
            foreach (var i in array)
            {
                Console.WriteLine(i.Name);
                Console.WriteLine(i.Integrate(1.0, 5.0, 0.0001, new Func<double, double>(f)));
            }
        }
    }
}