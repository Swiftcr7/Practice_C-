namespace Task4;

public interface IDefiniteIntegral
{
    public string Name
    {
        get;
    }

    public double Integrate(double a, double b, double epsilon, Func<double, double> function);

}