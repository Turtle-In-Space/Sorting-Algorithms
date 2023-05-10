using System.Threading.Tasks;

public class QuickSort : SortingAlgorithm
{
    protected override int[] Sort(int[] array)
    {
        _QuickSort(array, 0, array.Length - 1);

        return array;
    }

    protected override async void VisualSort(int[] array, int timeStep)
    {
        await VisualQuickSort(array, 0, array.Length - 1, timeStep);
    }

    private async Task VisualQuickSort(int[] array, int start, int end, int timeStep)
    {
        if (start < end)
        {
            int pivot = await VisualPartion(array, start, end, timeStep);

            await VisualQuickSort(array, start, pivot - 1, timeStep);
            await VisualQuickSort(array, pivot + 1, end, timeStep);
        }
    }

    //TODO
    /* Mark pivot
     * mark curently searching 
     * Mark back dude
     * 
     */
    private async Task<int> VisualPartion(int[] array, int start, int end, int timeStep)
    {
        int pivot = array[end];
        VisualBox.instance.ChangePillarColor(end, PillarColor.pivot);

        int i = start - 1;

        for (int j = start; j <= end - 1; ++j)
        {
            VisualBox.instance.ChangePillarColor(j, PillarColor.compare);

            if (array[j] < pivot)
            {
                if(i >= start)
                {
                    VisualBox.instance.ChangePillarColor(i, PillarColor.normal);
                }
                i++;
                VisualBox.instance.ChangePillarColor(i, PillarColor.active);
                await VisualSwap(array, i, j, timeStep);
            }
            VisualBox.instance.ChangePillarColor(j, PillarColor.normal);
        }

        VisualBox.instance.ChangePillarColor(end, PillarColor.normal);
        if (i >= start)
        {
            VisualBox.instance.ChangePillarColor(i, PillarColor.normal);
        }

        VisualBox.instance.ChangePillarColor(i+1, PillarColor.active);
        VisualBox.instance.ChangePillarColor(end, PillarColor.compare);
        await VisualSwap(array, i + 1, end, timeStep);
        VisualBox.instance.ChangePillarColor(i + 1, PillarColor.normal);
        VisualBox.instance.ChangePillarColor(end, PillarColor.normal);

        return i + 1;
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
     * returns pivot
     */
    private int Partion(int[] array, int start, int end)
    {
        int pivot = array[end];
        int i = start - 1;

        for (int j = start; j <= end - 1; ++j)
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
