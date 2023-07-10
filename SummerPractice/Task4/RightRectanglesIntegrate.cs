namespace Task4;

public class RightRectanglesIntegrate : IDefiniteIntegral
{
    public string Name => "RightRectanglesIntegrate";

    public double Integrate(double a, double b, double epsilon, Func<double, double> function)
    {
        var flag = false;
        if (function == null)
        {
            throw new ArgumentNullException("No function");
        }

        if (epsilon <= 0)
        {
            throw new ArgumentException(nameof(epsilon));
        }
        

        if (a.CompareTo(b)>0)
        {
            flag = true;
            (b, a) = (a, b);
        }
        var n = 1;
        var prev = 0d;
        var current = 1.0;
        while (Math.Abs(current-prev)>=epsilon)
        {
            var h = (b - a) / n;
            var sum = 0d;
            for (int i = 1; i < n+1; i++)
            {
                var x = a + i * h;
                sum += function(x);

            }

            prev = current;
            current = sum * h;
            n *= 2;
        }
        if (flag)
        {
            current = -current;
        }
        return current;
    }
}