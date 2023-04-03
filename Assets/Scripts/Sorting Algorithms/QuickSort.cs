public class QuickSort : SortingAlgorithm
{
    public override int[] Sort(int[] array)
    {
        _QuickSort(array, 0, array.Length - 1);

        return array;
    }

    /*
     * Recursivly divides array
     */
    private void _QuickSort(int[] array, int start, int end)
    {
        if (start < end)
        {
            int pivot = Partion(array, start, end);

            _QuickSort(array, start, pivot - 1);
            _QuickSort(array, pivot + 1, end);
        }       
    }    

    /*
     * Sorts array into lower and higher half
     * returns pivor
     */
    private int Partion(int[] array, int start, int end)
    {
        int pivot = array[end];
        int i = start - 1;

        for (int j = start; j <= end - 1; j++)
        {
            if (array[j] < pivot)
            {
                i++;

                Swap(array, i, j);
            }
        }

        Swap(array, i + 1, end);
        return i + 1;
    }
}
