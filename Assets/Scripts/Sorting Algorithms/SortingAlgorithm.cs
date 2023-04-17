using UnityEngine;


public class SortingAlgorithm : MonoBehaviour
{
    public virtual int[] Sort(int[] array)
    {
        print("oops this shouldn't happen");
        return null;
    }

    protected void Swap(int[] array, int i, int j)
    {
        int temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }
}

