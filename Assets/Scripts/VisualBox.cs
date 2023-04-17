using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualBox : MonoBehaviour
{
    public static VisualBox instance;

    [SerializeField] private GameObject pillarPrefab;

    private Transform pillarParent;
    private GameObject[] pillars;

    private float boxWidth = 570f;
    private float maxPillarHeight = 210f;


    private void Awake()
    {
        instance = this;        
    }

    private void Start()
    {
        pillarParent = transform.GetChild(1);
    }

    public void DrawPillars(int[] array)
    {
        pillars = new GameObject[array.Length];
        ClearBox();

        float pillarWidth = boxWidth / array.Length;

        for (int i = 0; i < array.Length; i++)
        {
            Vector3 position = new(pillarWidth * i + pillarWidth/2, 0, 0);

            float pillarHeight = maxPillarHeight - (maxPillarHeight * (array.Length - array[i]) / array.Length);

            GameObject pillar = Instantiate(pillarPrefab, pillarParent.TransformPoint(position), Quaternion.identity, pillarParent);            
            pillar.GetComponent<Pillar>().SetSize(pillarWidth, pillarHeight);
            pillars[i] = pillar;
        }
    }

    public void SwapPillars(int i, int j)
    {
        Vector3 positionI = pillars[i].transform.position;
        Vector3 positionJ = pillars[j].transform.position;

        pillars[i].transform.position = pillarParent.TransformPoint(pillars[i].transform.position = new(positionJ.x, positionI.y));
        pillars[j].transform.position = pillarParent.TransformPoint(new(positionI.x, positionJ.y));
    }

    private void ClearBox()
    {
        foreach (Transform pillar in pillarParent)
        {
            Destroy(pillar.gameObject);
        }
    }
}
