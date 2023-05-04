using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class VisualBox : MonoBehaviour
{
    public static VisualBox instance;

    [SerializeField] private GameObject pillarPrefab;
    [SerializeField] private Transform pillarParent;

    private GameObject[] pillars;
    private bool[] activePillars;

    private const float BOX_WIDTH = 540;
    private const float MAX_PILLAR_HEIGHT = 265;
    private const int MAX_PILLARS = 1000;


    private void Awake()
    {
        instance = this;
        pillars = new GameObject[MAX_PILLARS];
        activePillars = new bool[MAX_PILLARS];

        InitPillars();
    }


    public void DrawPillars(int[] array)
    {
        float pillarWidth = BOX_WIDTH / array.Length;

        //Puts pillar in correct pos and correct size
        for (int i = 0; i < array.Length; i++)
        {
            GameObject pillar = pillars[i];

            Vector3 position = new(pillarWidth * i + pillarWidth / 2, 0, 0);
            float pillarHeight = MAX_PILLAR_HEIGHT - (MAX_PILLAR_HEIGHT * (array.Length - array[i]) / array.Length);

            pillar.transform.position = pillarParent.TransformPoint(position);
            pillar.GetComponent<Pillar>().SetSize(pillarWidth, pillarHeight);
            activePillars[i] = true;
        }

        //Removes unused pillars
        for (int i = array.Length; i < MAX_PILLARS; i++)
        {
            GameObject pillar = pillars[i];

            pillar.transform.position = new Vector2(0, 0);
            pillar.GetComponent<Pillar>().SetSize(0, 0);
        }
    }
    

    public void SwapPillars(int i, int j)
    {
        Vector3 positionI = pillars[i].transform.position;
        Vector3 positionJ = pillars[j].transform.position;

        pillars[i].transform.position = pillarParent.TransformPoint(pillars[i].transform.position = new(positionJ.x, positionI.y));
        pillars[j].transform.position = pillarParent.TransformPoint(new(positionI.x, positionJ.y));
    }

    private void InitPillars()
    {        
        for (int i = 0; i < MAX_PILLARS; i++)
        {
            pillars[i] = Instantiate(pillarPrefab, pillarParent.position, Quaternion.identity, pillarParent);
        }
    }
}