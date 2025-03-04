internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Введите массив чисел: ");
        var input = Console.ReadLine() ?? throw new ArgumentNullException("Пустой ввод");
        var stringNums = input.Split([" ", ",", ";", ":"], StringSplitOptions.RemoveEmptyEntries);
        var array = new int[stringNums.Length];
        for (var i = 0; i < stringNums.Length; ++i) {
            array[i] = int.Parse(stringNums[i]);
        }

        var sortedArray = BubbleSort(array);
        Console.WriteLine("Отсортированый массив: {0}", string.Join(", ", sortedArray));
    }

    private static int[] BubbleSort(int[] array) {
        var len = array.Length;
        for (var i = 1; i < len; ++i) {
            for (var j = 0; j < len -1; ++j) {
                if (array[j] > array[j + 1]) {
                    Swap(ref array[j], ref array[j + 1]);
                }
            }
        }

        return array;
    }

    private static void Swap(ref int num1, ref int num2) {
        var tmp = num1;
        num1 = num2;
        num2 = tmp;
    }
}