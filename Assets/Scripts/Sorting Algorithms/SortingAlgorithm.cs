using System;
using System.Threading.Tasks;
using UnityEngine;


public class SortingAlgorithm : MonoBehaviour
{
    public virtual void RunAlgorithm(int[] array)
    {
        if (ModeSelection.instance.VisualMode)
        {
            VisualSort(array, VisualSettings.instance.TimeStep);
        }
        else if (ModeSelection.instance.TimedMode)
        {
            int[] sorted = TimedSort(array);
            VisualBox.instance.DrawPillars(sorted);
        }
    }

    protected virtual async void VisualSort(int[] array, int timeStep)
    {
        throw new NotImplementedException();
    }

    protected int[] TimedSort(int[] array)
    {
        int[] _array = new int[array.Length];

        DateTime start = DateTime.Now;
        for (int i = 0; i < TimerSettings.instance.Iterations; i++)
        {
            array.CopyTo(_array, 0);
            Sort(_array);
        }
        DateTime end = DateTime.Now;

        double time = end.Subtract(start).TotalSeconds;
        TimerSettings.instance.DisplayResult(time);

        return _array;
    }

    protected virtual int[] Sort(int[] array)
    {
        throw new NotImplementedException();
    }

    protected void Swap(int[] array, int i, int j)
    {
        int temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }

    protected async Task VisualSwap(int[] array, int i, int j, int timeStep)
    {
        VisualBox.instance.SwapPillars(i, j);
        int temp = array[i];
        array[i] = array[j];
        array[j] = temp;
        await Task.Delay(timeStep);
    }
}

