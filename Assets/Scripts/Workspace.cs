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
    [SerializeField] private TextMeshProUGUI elementNumber;
    [SerializeField] private TextMeshProUGUI sortTime;

    private SortingAlgorithm[] algorithms;

    private int amountOfElements;
    private int[] array;



    private void Awake()
    {
        algorithms = GetComponents<SortingAlgorithm>();
    }

    public void Run()
    {                      
        DateTime start = DateTime.Now;
        algorithms[algorithmSelect.value - 1].Sort(array);
        double time = (DateTime.Now - start).TotalMilliseconds;

        VisualBox.instance.DrawPillars(array);

        sortTime.text = "TIME: " + time + " ms";
    }

    public void OnValueChanged()
    {
        amountOfElements = (int)slider.value;
        elementNumber.text = slider.value.ToString();
        array = InitArray(amountOfElements);
        VisualBox.instance.DrawPillars(array);
    }

    private int[] InitArray(int elements)
    {
        int[] _array = new int[elements];

        for (int i = 0; i < elements; i++)
        {
            _array[i] = i + 1;
        }

        for (int i = 0; i < elements; i++)
        {
            int randPos = UnityEngine.Random.Range(1, elements);
            int temp = _array[i];

            _array[i] = _array[randPos];
            _array[randPos] = temp;
        }

        return _array;
    }
}
