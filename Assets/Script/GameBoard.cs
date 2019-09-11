using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameBoard : MonoBehaviour
{
    [SerializeField]
    private RectTransform rectTransform;

    private float width;
    private float height;

    [SerializeField]
    private int gridNum;

    // Start is called before the first frame update
    void Start()
    {
        width = rectTransform.sizeDelta.x;
        height = rectTransform.sizeDelta.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public (Vector3, bool) NearestSquare(Vector3 square)
    {
        Debug.Log("Vector3(" + square.x + "," + square.y + ",0)");
        Vector3 nearestSquare;
        float nearestX;
        float nearestY;

        var x = NearestNum(square.x, width);
        var y = NearestNum(square.y, height);

        if(!(x.Item2 && y.Item2))
        {
            return (Vector3.one, false);
        }

        nearestX = x.Item1;
        nearestY = y.Item1;

        nearestSquare = new Vector3(nearestX, nearestY, 0);

        return (nearestSquare, true);
    }

    private (float, bool) NearestNum(float num, float orientation)
    {
        /*
        if(Math.Abs(num) <= orientation / 2)
        {
            return 0;
        }
        */
        
        float edge = -(orientation / 2);
        Debug.Log(edge);
        for (int i = 0; i <  gridNum; i++)
        {
            if(num >= edge + ((orientation / gridNum) * i)  && num <= edge + ((orientation / gridNum) * (i + 1)))
            {
                Debug.Log("i : " + i);
                Debug.Log("orientation / gridNum = " + orientation + "/" + gridNum + "= " + orientation / gridNum);
                Debug.Log((orientation / gridNum) * (i + (1 / 2)));
                return (edge + ((orientation / gridNum) / 2 * (2 * i + 1)), true);
            }
        }
        return (0, false);
    }
}
