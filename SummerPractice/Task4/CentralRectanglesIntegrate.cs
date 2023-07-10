namespace Task4;

public class CentralRectanglesIntegrate : IDefiniteIntegral
{
    public string Name => "CentralRectanglesIntegrate";

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
            var sum = (function(b)-function(a))/2;
            for (int i = 1; i < n; i++)
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