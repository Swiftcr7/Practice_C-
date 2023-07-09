namespace Task3;

public static class ExtensionsSort
{
     
    public enum Method
    {
        Increasing,
        Decreasing
    }

    public enum Algorithm
    {
        Inserts,
        Choice,
        Pyramidal,
        Fast,
        Merging
    }

    public static T[] MySort<T>(this T[]? collection, Method method, Algorithm algorithm)
        where T : IComparable<T>
    {
        
        if (collection == null)
        {
            throw new ArgumentException(nameof(collection));
        }
        if (collection.Clone() is not T[] result) throw new ArgumentException("Error!");
        
        var  myDelegate = new Comparison<T?>((x, y) =>
        {
            if (x == null && y != null) return -1;
            if (x != null && y == null) return 1;
            if (x == null && y == null) return 0;
            if (x != null && y != null) return x.CompareTo(y);
            return 0;
        });
        Choose_Algorithm(result, algorithm, method, myDelegate);

        return result; 
    }

    public static T[] MySort<T>(this T[]? collection, Method method, Algorithm algorithm, IComparer<T>? comparator)
    {
        if (collection == null)
        {
            throw new ArgumentException(nameof(collection));
        }

        if (comparator == null)
        {
            throw new ArgumentException(nameof(comparator));
        }

        if (collection.Clone() is not T[] result) throw new ArgumentException("Error!");
        var  myDelegate = new Comparison<T>(comparator.Compare);

        Choose_Algorithm(result, algorithm, method, myDelegate);

        return result;
    }
    
    public static T[] MySort<T>(this T[]? collection, Method method, Algorithm algorithm, Comparer<T>? comparator)
    {
        if (collection == null)
        {
            throw new ArgumentException(nameof(collection));
        }
        
        if (comparator == null)
        {
            throw new ArgumentException(nameof(comparator));
        }

        if (collection.Clone() is not T[] result) throw new ArgumentException("Error!");
        var  myDelegate = new Comparison<T>(comparator.Compare);

        Choose_Algorithm(result, algorithm, method, myDelegate);
        return result;
    }
    
    public static T[] MySort<T>(this T[]? collection, Method method, Algorithm algorithm, Comparison<T>? comparator)
    {
        if (collection == null)
        {
            throw new ArgumentException(nameof(collection));
        }
        if (comparator == null)
        {
            throw new ArgumentException(nameof(comparator));
        }

        if (collection.Clone() is not T[] result) throw new ArgumentException("Error!");
        var  myDelegate = new Comparison<T>(comparator);

        Choose_Algorithm(result, algorithm, method, myDelegate);

        return result;
    }

    private static void Choose_Algorithm<T>(T[] array, Algorithm algorithm, Method method, Comparison<T> myDelegate)
    {
        if (Algorithm.Inserts == algorithm)
        { 
            InsertSort(array, method, myDelegate);
        }else if (algorithm == Algorithm.Choice)
        {
            ChoiceSort(array, method, myDelegate);
        }else if (algorithm == Algorithm.Pyramidal)
        {
            PyramidalSort(array, method, myDelegate);
        }else if (algorithm == Algorithm.Fast)
        {
            FastSort(array, method, myDelegate);
        }else if (algorithm==Algorithm.Merging)
        {
            MergeSort(array, myDelegate, method);
        }
        else
        {
            throw new ArgumentOutOfRangeException("Uncorect algorithm");
        }
    }

    private static void InsertSort<T>(T[] array, Method method, Comparison<T> comparator)

    {
        int methodIndex;
        if (method == Method.Decreasing)
        {
            methodIndex = -1;
        }
        else
        {
            methodIndex = 1;
        }
        int size = array.Length;
        for (int i = 1; i < size; i++)
        {
            var value = array[i];
            int j = i - 1;
            while (j>=0 && comparator.Invoke(array[j], value)==methodIndex)
            {
                array[j + 1] = array[j];
                j--;
            }

            array[j + 1] = value;
        }
    }
    private static void ChoiceSort<T>(T[] array, Method method, Comparison<T> comparator)
    {
        int methodIndex;
        if (method == Method.Decreasing)
        {
            methodIndex = 1;
        }
        else
        {
            methodIndex = -1;
        }
        int size = array.Length;
        for (int i = 0; i < size - 1; i++)
        {
            var indexValue = i;
            for (int j = i + 1; j < size; j++)
            {
                if (comparator.Invoke(array[j], array[indexValue]) == methodIndex)
                {
                    indexValue = j;
                }
            }
            (array[i], array[indexValue]) = (array[indexValue], array[i]);
        }
    } 
    private static void PyramidalSort<T>(T[] array, Method method, Comparison<T> comparator)
    {
        int size = array.Length;
        for (int i = size / 2 - 1; i >= 0; i--)
        {
            CreateBunch(i, size, array, comparator, method);
        }

        for (int i = size - 1; i > 0; i--)
        {
            (array[0], array[i]) = (array[i], array[0]);
            CreateBunch(0, i, array, comparator, method);
        }
    }

    private static void CreateBunch<T>(int index, int size, T[] array, Comparison<T> comparator,Method method)
    {
    
        int methodIndex;
        if (method == Method.Decreasing)
        {
            methodIndex = -1;
        }
        else
        {
            methodIndex = 1;
        }
        int left = 2 * index + 1;
        int right = 2 * index + 2;
        int largest = index;
        if (left < size && comparator.Invoke(array[left], array[largest]) == methodIndex)
        {
            largest = left;
        }
        if ( right < size && comparator.Invoke(array[right], array[largest]) == methodIndex)
        {
            largest = right;
        }

        if (index != largest)
        {
            (array[largest], array[index]) = (array[index], array[largest]);
            CreateBunch(largest, size, array, comparator, method);
        }
    }

    private static void FastSort<T>(T[] array, Method method, Comparison<T> comparator)
    {
        FastSort(array, method, comparator, array.Length-1, 0);
    }
    
    private static void FastSort<T>(T[] array, Method method, Comparison<T> comparator, int maxIndex, int minIndex)
    {
        if (minIndex < maxIndex)
        {
            var support = Support(array, maxIndex, minIndex, method, comparator);
            FastSort(array, method, comparator, support-1, minIndex);
            FastSort(array, method, comparator, maxIndex, support+1);
        }
    }
    private static int Support<T>(T[] array, int maxIndex, int minIndex, Method method, Comparison<T> comparator)
    {
        int methodIndex;
        if (method == Method.Decreasing)
        {
            methodIndex = 1;
        }
        else
        {
            methodIndex = -1;
        }
        int support = minIndex - 1;
        int size = array.Length;
        for (int i = minIndex; i < size; i++)
        {
            if (comparator.Invoke(array[i], array[maxIndex]) == methodIndex)
            {
                support++;
                (array[i], array[support]) = (array[support], array[i]);
            }
        }

        support++;
        (array[maxIndex], array[support]) = (array[support], array[maxIndex]);
        return support;
    }

  
    private static void MergeSort<T>(T[] arr, Comparison<T> comparer, Method order)
    {
        var comparerIndex = order == Method.Increasing? -1 : 1;
        MergeSortRecursion(arr, 0, arr.Length - 1, comparer, comparerIndex);
    }
    
    private static void MergeSortRecursion<T>(T[] array, int lowIndex, int highIndex, Comparison<T> comparer, int comparerIndex)
    {
        if (lowIndex >= highIndex) return;
        var middleIndex = (lowIndex + highIndex) / 2;
        MergeSortRecursion(array, lowIndex, middleIndex, comparer, comparerIndex);
        MergeSortRecursion(array, middleIndex + 1, highIndex, comparer, comparerIndex);
        Merge(array, lowIndex, middleIndex, highIndex, comparer, comparerIndex);
    }
    private static void Merge<T>(T[] arr, int lowIndex, int middleIndex, int highIndex, Comparison<T> comparer, int comparerIndex)
    {
        var left = lowIndex;
        var right = middleIndex + 1;
        var tempArr = new T[highIndex - lowIndex + 1];
        var index = 0;

        while (left <= middleIndex && right <= highIndex)
        {
            if (comparer.Invoke(arr[left], arr[right]) == comparerIndex)
            {
                tempArr[index] = arr[left];
                left++;
            }
            else
            {
                tempArr[index] = arr[right];
                right++;
            }
            index++;
        }

        for (var i = left; i <= middleIndex; i++)
        {
            tempArr[index] = arr[i];
            index++;
        }

        for (var i = right; i <= highIndex; i++)
        {
            tempArr[index] = arr[i];
            index++;
        }

        for (var i = 0; i < tempArr.Length; i++) 
            arr[lowIndex + i] = tempArr[i];
    }

}
