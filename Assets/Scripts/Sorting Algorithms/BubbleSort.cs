using System.Threading.Tasks;

public class BubbleSort : SortingAlgorithm
{
    protected override int[] Sort(int[] array)
    {
        return _BubbleSort(array);
    }

    protected override async void VisualSort(int[] array, int timeStep)
    {
        await VisualBubbleSort(array, timeStep);
    }

    protected async Task VisualBubbleSort(int[] array, int timeStep)
    {
        int len = array.Length;

        for (int i = 0; i < len - 1; i++)
        {
            for (int j = 0; j < len - i - 1; j++)
            {
                VisualBox.instance.ChangePillarColor(j, PillarColor.active);
                VisualBox.instance.ChangePillarColor(j+1, PillarColor.compare);
                await Task.Delay(timeStep);

                if (array[j] > array[j + 1])
                {
                    await VisualSwap(array, j, j + 1, timeStep);

                    VisualBox.instance.ChangePillarColor(j, PillarColor.normal);
                    VisualBox.instance.ChangePillarColor(j + 1, PillarColor.normal);
                }
                else
                {
                    VisualBox.instance.ChangePillarColor(j, PillarColor.normal);
                    VisualBox.instance.ChangePillarColor(j + 1, PillarColor.normal);
                }
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
