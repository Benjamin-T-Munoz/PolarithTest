using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoBehaviour {

    GameObject pointHolder;
    public List<GameObject> points = new List<GameObject>();
    public List<bool> occupiedPoint = new List<bool>();
    // Use this for initialization
    void Awake()
    {
        Transform[] ts = gameObject.GetComponentsInChildren<Transform>();
        pointHolder = transform.GetChild(0).gameObject;
        foreach (Transform t in ts)
        {
            if (t != null && t.gameObject != null)
                points.Add(t.gameObject);
            occupiedPoint.Add(false);
        }
    }

    public bool PointEmpty(int index)
    {
        if (index < occupiedPoint.Count)
        {
            if (!occupiedPoint[index])
            {
                return true;
            }
        }
        return false;
    }

    public int NewPosition()
    {
        int placeHolder = -1;

        while (placeHolder == -1)
        {
            int i = Random.Range(0, occupiedPoint.Count);
            if (!occupiedPoint[i])
            {
                occupiedPoint[i] = true;
                placeHolder = i;
                break;
            }
        }
        return placeHolder;
    }

    public void FreePosition(int index)
    {
        if (index < occupiedPoint.Count)
        {
            occupiedPoint[index] = false;
        }
    }



}
