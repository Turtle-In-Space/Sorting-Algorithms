using System.Threading.Tasks;
using UnityEngine;


public class BogoSort : SortingAlgorithm
{

    protected override int[] Sort(int[] array)
    {
        _BogoSort(array, array.Length);

        return array;
    }

    protected override async void VisualSort(int[] array, int timeStep)
    {
        await VisualBogoSort(array, timeStep);
    }

    
    protected async Task VisualBogoSort(int[] array, int timeStep)
    {
        while (!isSorted(array, array.Length))
        {
            Shuffle(array, array.Length);
            VisualBox.instance.DrawPillars(array);
            await Task.Delay(timeStep);
        }
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
        for (int index = 0; index < len; ++index)
        {
            int rand = Random.Range(0, len);
            Swap(array, index, rand);
        }
    }
}