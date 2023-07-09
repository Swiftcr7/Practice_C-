

namespace Task2;



public static class Extensions
{
    private static void CheckMatch<T>(this IEnumerable<T> collection,IEqualityComparer<T> comparator)
    {
        var x = collection.Distinct(comparator);
        if (x.Count() != collection.Count())
        {
            throw new ArgumentException("there are the same arguments");
        }
    }

    public static IEnumerable<IEnumerable<T>> generating_combinations<T>(this IEnumerable<T>? collection, int count,
        IEqualityComparer<T>? comparer)
    {
        if (collection == null)
        {
            throw new ArgumentNullException(nameof(collection));
        }

        if (comparer == null)
        {
            throw new ArgumentNullException(nameof(comparer));
        }

        if (count < 0)
        {
            throw new ArgumentException("Uncorrect Argument", nameof(count));
        }
        collection.CheckMatch(comparer);
        var result = new List<List<T>>();
        var current = new List<T>();
        generating_all_combinations<T>(0, count, result, current, collection.ToList());

        return result;
    }

    private static void generating_all_combinations<T>(int index, int count, List<List<T>> result, 
        List<T> current, List<T> collection)
    {
        if (count == current.Count)
        {
            result.Add(current.ToList());
            return;
        }

        int size = collection.Count;

        for (int i = index; i < size; i++)
        {
            current.Add(collection[i]);
            generating_all_combinations<T>(i, count, result, current, collection);
            current.RemoveAt(current.Count-1);
        }
    }

    public static IEnumerable<IEnumerable<T>> all_possible_subsets<T>(this IEnumerable<T>? collection,
        IEqualityComparer<T>? comparator)
    {
        if (collection == null)
        {
            throw new ArgumentException(nameof(collection));
        }

        if (comparator == null)
        {
            throw new ArgumentException(nameof(comparator));
        }
        collection.CheckMatch(comparator);
        var sourceList = collection.ToList();
        var result = new List<List<T>>();
        int size = sourceList.Count;
        for (int i = 0; i < (1 << size); i++)
        {
            result.Add(new List<T>());
            for (int j = 0; j < size; j++)
            {
                if ((i & (1 << j))!=0)
                {
                    result.Last().Add(sourceList[j]);
                }
            }
        }
        result.Sort((x, y) => x.Count.CompareTo(y.Count));

        return result;
    }

    public static IEnumerable<IEnumerable<T>> All_possible_combinations<T>(this IEnumerable<T>? collection,
        IEqualityComparer<T>? comparator)
    {
        if (collection == null)
        {
            throw new ArgumentException(nameof(collection));
        }

        if (comparator == null)
        {
            throw new ArgumentException(nameof(comparator));
        }
        collection.CheckMatch(comparator);
        var current = new List<T>();
        var result = new List<List<T>>();
        ALL_possible_combinations_realization(collection.ToList(), current, result);
        return result;
    }

    private static void ALL_possible_combinations_realization<T>(List<T> collection, List<T> current,
        List<List<T>> result)
    {
        if (collection.Count == 0)
        {
            result.Add(current);
            return;
        }

        int size = collection.Count;
        for (int i = 0; i < size; i++)
        {
            var newclollection = new List<T>(collection);
            newclollection.RemoveAt(i);
            var newCurrent = new List<T>(current) { collection[i] };
            ALL_possible_combinations_realization<T>(newclollection, newCurrent, result);
        }
    }

}
