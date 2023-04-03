using UnityEngine;


public class BogoSort : SortingAlgorithm
{
    public override int[] Sort(int[] array)
    {
        _BogoSort(array, array.Length);

        return array;
    }


    private void _BogoSort(int[] array, int len)
    {
        while (!isSorted(array, len))
        {
            Shuffle(array, len);
        }
    }    

    private bool isSorted(int[] array, int index)
    {
        while (index-- > 1)
        {
            if (array[index] < array[index - 1])
            {
                return false;
            }
        }

        return true;
    }

    private void Shuffle(int[] array, int len)
    {
        for (int index = 0; index < len; index++)
        {
            int rand = Random.Range(0, len);
            Swap(array, index, rand);
        }
    }
}