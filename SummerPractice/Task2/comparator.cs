namespace Task2;

public class MyComparer: IEqualityComparer<primer>
{
    private static MyComparer? _instance;
    private MyComparer(){}
    
    public static MyComparer Instance => 
        _instance ??= new MyComparer();

    public bool Equals(
        primer? x,
        primer? y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (ReferenceEquals(x, null)) return false;
        if (ReferenceEquals(y, null)) return false;
        if (x.GetType() != y.GetType()) return false;
        return x.Size.Equals(y.Size);
    }

    public int GetHashCode(
        primer obj)
    {
        return obj.Size.GetHashCode();
    }
}