public class BubbleSort : SortingAlgorithm
{
    protected override int[] Sort(int[] array)
    {
        return _BubbleSort(array);
    }

    private int[] _BubbleSort(int[] array)
    {
        int len = array.Length;

        for (int i = 0; i < len - 1; i++)
        {
            for (int j = 0; j < len - i - 1; j++)
            {
                if (array[j] > array[j + 1])
                {
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }
        
        return array;
    }
}
