using UnityEngine;
using System;

public class GnomeSort : SortingAlgorithm
{
    protected override int[] Sort(int[] array)
    {
        return _GnomeSort(array);
    }

    private int[] _GnomeSort(int[] array)
    {
        array.CopyTo(array, 0);
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
