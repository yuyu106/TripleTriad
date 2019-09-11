using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameBoard : MonoBehaviour
{
    [SerializeField]
    private RectTransform _rectTransform;

    private float _width;
    private float _height;

    [SerializeField]
    private int gridNum;

    private bool[,] _usingGridArray;

    // Start is called before the first frame update
    void Start()
    {
        _width = _rectTransform.sizeDelta.x;
        _height = _rectTransform.sizeDelta.y;
        _usingGridArray = new bool[gridNum,gridNum];
        for(int i = 0; i < gridNum; i++)
        {
            for(int j = 0; j < gridNum; j++)
            {
                _usingGridArray[i, j] = true;
            }
        }
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

        var x = NearestNum(square.x, _width);
        var y = NearestNum(square.y, _height);

        if(!(x.Item2 && y.Item2))
        {
            return (Vector3.one, false);
        }

        if(!(_usingGridArray[x.Item3, y.Item3]))
        {
            return (Vector3.one, false);
        }

        _usingGridArray[x.Item3, y.Item3] = false;

        nearestX = x.Item1;
        nearestY = y.Item1;

        nearestSquare = new Vector3(nearestX, nearestY, 0);

        return (nearestSquare, true);
    }

    private (float, bool, int) NearestNum(float num, float orientation)
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
 //               Debug.Log("i : " + i);
 //               Debug.Log("orientation / gridNum = " + orientation + "/" + gridNum + "= " + orientation / gridNum);
 //               Debug.Log((orientation / gridNum) * (i + (1 / 2)));
                return (edge + ((orientation / gridNum)  * (i + 0.5f)), true, i);
            }
        }
        return (0, false, 0);
    }
}
