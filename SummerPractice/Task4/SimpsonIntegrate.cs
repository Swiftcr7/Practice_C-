namespace Task4;

internal class SimpsonIntegrate : IDefiniteIntegral
{
    public string Name => "SimpsonIntegrate";

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
            var sum1 = 0d;
            for (int i = 1; i <= n; i++)
            {
                var xk = a + i * h;
                if (i <= n - 1)
                {
                    sum1 += function(xk);
                }

                var xn = a + (i - 1) * h;
                sum += function((xn + xk) / 2);

            }

            prev = current;
            current = h / 3d * (1d / 2d * function(a) + sum1 + 2 * sum + 1d / 2d * function(b));
            n *= 2;
        }

        if (flag)
        {
            current = -current;
        }
        return current;
    }
}