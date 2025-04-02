internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Введите массив чисел: ");
        var input = Console.ReadLine() ?? throw new ArgumentNullException("Пустой ввод");
        var stringNums = input.Split([" ", ",", ";", ":"], StringSplitOptions.RemoveEmptyEntries);
        var array = new int[stringNums.Length];
        for (var i = 0; i < stringNums.Length; ++i)
        {
            array[i] = int.Parse(stringNums[i]);
        }

        QuickSort(array);
        Console.WriteLine("Отсортированый массив: {0}", string.Join(", ", array));
    }

    private static void QuickSort(int[] array)
    {
        if (array == null || array.Length == 0)
        return;
    
        QuickSortRecursive(array, 0, array.Length - 1);
    }

    private static void QuickSortRecursive(int[] array, int left, int right)
    {
        if (left < right)
        {
            int pivotIndex = Partition(array, left, right); // Находим опорный индекс

            QuickSortRecursive(array, left, pivotIndex - 1);  // Сортируем левую часть
            QuickSortRecursive(array, pivotIndex + 1, right); // Сортируем правую часть
        }
    }
    
    private static int Partition(int[] array, int left, int right)
    {
        int pivot = array[right];
        int i = left;
        
        for (int j = left; j < right; j++)
        {
            if (array[j] <= pivot)
            {
                Swap(ref array[i], ref array[j]);
                i++;
            }
        }
        
        Swap(ref array[i], ref array[right]);
        return i;
    }

    private static void Swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }
}