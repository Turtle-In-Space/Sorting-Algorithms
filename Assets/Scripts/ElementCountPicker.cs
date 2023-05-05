using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ElementCountPicker : MonoBehaviour
{
    [SerializeField] private TMP_InputField elementInput;

    private const int MAX_ELEMENT_COUNT = 1000;
    private const int MIN_ELEMENT_COUNT = 2;

    private int lastElementCount = MIN_ELEMENT_COUNT;


    private void Start()
    {
        elementInput.text = 10.ToString();
        UpdateElementCount(10.ToString());
    }

    public void UpdateElementCount(string value)
    {
        if(int.TryParse(value, out int elementCount))
        {
            if (elementCount > MAX_ELEMENT_COUNT)
            {
                elementInput.text = MAX_ELEMENT_COUNT.ToString();
                elementCount = MAX_ELEMENT_COUNT;
            }
            else if (elementCount < MIN_ELEMENT_COUNT)
            {
                elementInput.text = MIN_ELEMENT_COUNT.ToString();
                elementCount = MIN_ELEMENT_COUNT;
            }

            lastElementCount = elementCount;
            Workspace.instance.UpdateElementCount(elementCount);
        }

        else
        {
            elementInput.text = lastElementCount.ToString();
        }
    }
}
