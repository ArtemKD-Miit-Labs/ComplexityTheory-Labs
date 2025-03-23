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

        InsertionSort(array);
        Console.WriteLine("Отсортированый массив: {0}", string.Join(", ", array));
    }

    private static void InsertionSort(int[] array)
    {
        int n = array.Length;
        for (int i = 1; i < n; ++i)
        {
            int key = array[i];
            int j = i - 1;

            while (j >= 0 && array[j] > key)
            {
                array[j + 1] = array[j];
                --j;
            }
            array[j + 1] = key;
        }
    }
}