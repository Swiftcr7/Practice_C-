

namespace Task3;

public class Comparator: IComparer<int>
{
    public int Compare(int x, int y)
    {
        return Math.Abs(x).CompareTo(Math.Abs(y));
    }
}