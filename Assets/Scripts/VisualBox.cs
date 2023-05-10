using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum PillarColor
{
    normal,
    active,
    compare,
    pivot,
    done
}

public class VisualBox : MonoBehaviour
{
    public static VisualBox instance;

    [SerializeField] private GameObject pillarPrefab;
    [SerializeField] private Transform pillarParent;

    private const float BOX_WIDTH = 540;
    private const float MAX_PILLAR_HEIGHT = 265;
    private const int MAX_PILLARS = 1000;

    private GameObject[] pillars;
    private Color32[] pillarColors = new Color32[5] {
        new Color32(223, 113, 38, 255), //Normal
        new Color32(210, 64, 51, 255), //Active
        new Color32(239, 235, 102, 255), //Compare
        new Color32(138, 165, 219, 255), //Pivot
        new Color32(128, 226, 42, 255) //Done
    };

    private bool[] activePillars;


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

        pillars[i].transform.position = new(positionJ.x, positionI.y);
        pillars[j].transform.position = new(positionI.x, positionJ.y);

        GameObject temp = pillars[i];
        pillars[i] = pillars[j];
        pillars[j] = temp;
    }

    public void ChangePillarColor(int index, PillarColor color)
    {        
         pillars[index].GetComponent<Image>().color = pillarColors[(int)color];        
    }

    private void InitPillars()
    {        
        for (int i = 0; i < MAX_PILLARS; i++)
        {
            pillars[i] = Instantiate(pillarPrefab, pillarParent.position, Quaternion.identity, pillarParent);
        }
    }
}