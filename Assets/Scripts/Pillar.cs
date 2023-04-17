using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : MonoBehaviour
{
    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void SetSize(float width, float height)
    {
        rectTransform.sizeDelta = new Vector2(width, height);
        transform.localPosition = new Vector3(transform.localPosition.x, height / 2, transform.localPosition.z);
    }
}
