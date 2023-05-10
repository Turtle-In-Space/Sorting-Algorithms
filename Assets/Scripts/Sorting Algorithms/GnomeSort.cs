using System.Threading.Tasks;

public class GnomeSort : SortingAlgorithm
{
    protected override int[] Sort(int[] array)
    {
        return _GnomeSort(array);
    }

    protected override async void VisualSort(int[] array, int timeStep)
    {
        await VisualGnomeSort(array, timeStep);
    }

    private async Task VisualGnomeSort(int[] array, int timeStep)
    {
        int len = array.Length;
        int index = 0;

        while (index < len)
        {
            VisualBox.instance.ChangePillarColor(index, PillarColor.active);
            await Task.Delay(timeStep);
            if (index == 0)
            {
                VisualBox.instance.ChangePillarColor(index, PillarColor.normal);
                index++;
                VisualBox.instance.ChangePillarColor(index, PillarColor.active);
                await Task.Delay(timeStep);
            }
            VisualBox.instance.ChangePillarColor(index - 1, PillarColor.compare);
            await Task.Delay(timeStep);
            if (array[index] < array[index - 1])
            {
                await VisualSwap(array, index - 1, index, timeStep);

                VisualBox.instance.ChangePillarColor(index, PillarColor.normal);
                index--;
            }
            else
            {
                VisualBox.instance.ChangePillarColor(index - 1, PillarColor.normal);
                VisualBox.instance.ChangePillarColor(index, PillarColor.normal);
                index++;
                VisualBox.instance.ChangePillarColor(index, PillarColor.active);
            }
        }
    }

    private int[] _GnomeSort(int[] array)
    {
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
