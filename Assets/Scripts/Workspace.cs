using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public enum Algorithms
{
    Invalid,
    Bubble,
    Quick,
    Gnome,
    Bogo
}


public class Workspace : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown algorithmSelect;
    [SerializeField] private Slider slider;

    private SortingAlgorithm[] algorithms;

    private int amountOfElements;


    private void Awake()
    {
        algorithms = GetComponents<SortingAlgorithm>();
    }

    public void Run()
    {
        amountOfElements = (int)slider.value;
        int[] array = InitArray();
        VisualBox.instance.DrawPillars(array);

        print("Given array: ");
        PrintArray(array);

        DateTime start = DateTime.Now;
        algorithms[algorithmSelect.value - 1].Sort(array);
        double time = (DateTime.Now - start).TotalMilliseconds;

        print("Sorted array: ");
        PrintArray(array);
        print("Took: " + time + " ms");
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
            int randPos = UnityEngine.Random.Range(1, amountOfElements);
            int temp = array[i];

            array[i] = array[randPos];
            array[randPos] = temp;
        }

        return array;
    }
}
