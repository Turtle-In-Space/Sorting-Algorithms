using System;
using UnityEngine;


public class SortingAlgorithm : MonoBehaviour
{
    public virtual int[] Sort(int[] array)
    {
        if (ModeSelection.instance.VisualMode)
        {
            return VisualSort();
        }
        else if (ModeSelection.instance.TimedMode)
        {
            return TimedSort();
        }
        else
        {
            Debug.LogError("Nej nu blev de allt fel");
            return null;
        }
    }

    protected virtual int[] VisualSort()
    {
        throw new NotImplementedException();
    }

    protected virtual int[] TimedSort()
    {
        throw new NotImplementedException();
    }

    protected void Swap(int[] array, int i, int j)
    {
        int temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }
}

