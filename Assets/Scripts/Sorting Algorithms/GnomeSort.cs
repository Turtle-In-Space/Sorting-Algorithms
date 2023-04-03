public class GnomeSort : SortingAlgorithm
{
    public override int[] Sort(int[] array)
    {
        int len = array.Length;
        int index = 0;

        while (index < len)
        {
            if (index == 0)
            {
                index++;
            }
            if (array[index] < array[index - 1])
            {
                Swap(array, index - 1, index);
                index--;
            }
            else
            {
                index++;
            }
        }

        return array;
    }
}
