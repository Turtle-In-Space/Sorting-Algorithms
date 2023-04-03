using UnityEngine;
using TMPro;


public enum Algorithms
{
    Invalid,
    Bubble,
    Quick,
    Gnome
}


public class Workspace : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown algorithmSelect;
    [SerializeField] private TMP_InputField input;

    private SortingAlgorithm[] algorithms;

    private int amountOfElements;


    private void Awake()
    {
        algorithms = GetComponents<SortingAlgorithm>();
    }


    public void OnInputChanged()
    {
        amountOfElements = int.Parse(input.text);
    }

    public void Run()
    {
        int[] array = InitArray();

        print("Given array: ");
        PrintArray(array);

        print("Sorted array: ");
        PrintArray(algorithms[algorithmSelect.value - 1].Sort(array));    
    }

    private void PrintArray(int[] array)
    {
        string temp = "";

        for (int i = 0; i < array.Length; i++)
        {
            temp += array[i] + " ";
        }

        print(temp);
    }

    private int[] InitArray()
    {
        int[] array = new int[amountOfElements];

        for (int i = 0; i < amountOfElements; i++)
        {
            array[i] = i + 1;
        }

        for (int i = 0; i < amountOfElements; i++)
        {
            int randPos = Random.Range(1, amountOfElements);
            int temp = array[i];

            array[i] = array[randPos];
            array[randPos] = temp;
        }

        return array;
    }
}
