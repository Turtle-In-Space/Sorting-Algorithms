using System.Collections;
using UnityEngine;

public class BubbleSort : SortingAlgorithm
{
    protected override int[] Sort(int[] array)
    {
        return _BubbleSort(array);
    }

    protected override IEnumerator ShowSteps(int[] array, WaitForSeconds timeStep)
    {
        int len = array.Length;

        for (int i = 0; i < len - 1; i++)
        {
            for (int j = 0; j < len - i - 1; j++)
            {
                VisualBox.instance.ChangePillarColor(j, PillarColor.active);
                VisualBox.instance.ChangePillarColor(j + 1, PillarColor.compare);
                yield return timeStep;

                if (array[j] > array[j + 1])
                {
                    VisualBox.instance.SwapPillars(j, j + 1);
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                    
                    yield return timeStep;
                    
                }
                VisualBox.instance.ChangePillarColor(j, PillarColor.normal);
                VisualBox.instance.ChangePillarColor(j + 1, PillarColor.normal);
            }
        }
    }


    private int[] _BubbleSort(int[] array)
    {
        int len = array.Length;

        for (int i = 0; i < len - 1; ++i)
        {
            for (int j = 0; j < len - i - 1; ++j)
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
