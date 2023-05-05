using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DropDownController : MonoBehaviour
{
    public static DropDownController instance;

    [SerializeField] private TMP_Dropdown dropdown;
    [SerializeField] private GameObject algorithmsParent;

    private List<string> options = new();
    private List<SortingAlgorithm> algorithms = new();

    private void Awake()
    {
        instance = this;

        foreach (SortingAlgorithm algorithm in algorithmsParent.GetComponents<SortingAlgorithm>())
        {
            options.Add(algorithm.GetType().ToString());
            algorithms.Add(algorithm);
        }

        dropdown.AddOptions(options);
    }

    public SortingAlgorithm GetSortingAlgorithm()
    {
        return algorithms[dropdown.value];
    }
}
