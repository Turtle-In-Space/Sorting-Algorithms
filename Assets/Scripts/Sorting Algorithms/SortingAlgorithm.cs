using System;
using UnityEngine;


public class SortingAlgorithm : MonoBehaviour
{
    public virtual int[] RunAlgorithm(int[] array)
    {
        if (ModeSelection.instance.VisualMode)
        {
            return VisualSort(array);
        }
        else if (ModeSelection.instance.TimedMode)
        {
            return TimedSort(array);
        }
        else
        {
            Debug.LogError("Nej nu blev de allt fel");
            return null;
        }
    }

    protected virtual int[] VisualSort(int[] array)
    {
        throw new NotImplementedException();
    }

    protected virtual int[] TimedSort(int[] array)
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
        return null;
    }

    protected void Swap(int[] array, int i, int j)
    {
        int temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }
}

