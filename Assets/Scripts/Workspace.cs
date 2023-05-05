using System;
using UnityEngine;
using TMPro;


public class Workspace : MonoBehaviour
{
    public static Workspace instance;

    [SerializeField] private GameObject algorithmsParent;
    [SerializeField] private TMP_Dropdown algorithmDropdown;

    private int[] array;
    private int elementCount;


    private void Awake()
    {
        instance = this;
    }

    public void Run()
    {
        DropDownController.instance.GetSortingAlgorithm().Sort(array);
        VisualBox.instance.DrawPillars(array);
    }

    public void UpdateElementCount(int value)
    {
        elementCount = value;
        InitArray();
        VisualBox.instance.DrawPillars(array);
    }

    public void Shuffle()
    {
        for (int i = 0; i < elementCount; i++)
        {
            int randPos = UnityEngine.Random.Range(1, elementCount - 1);
            int temp = array[i];

            array[i] = array[randPos];
            array[randPos] = temp;
        }

        VisualBox.instance.DrawPillars(array);
    }

    private void InitArray()
    {
        array = new int[elementCount];

        for (int i = 0; i < elementCount; i++)
        {
            array[i] = i + 1;
        }

        Shuffle();
    }
}
