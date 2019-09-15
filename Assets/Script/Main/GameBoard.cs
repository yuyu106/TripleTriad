using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameBoard : MonoBehaviour
{
    [SerializeField]
    private RectTransform _rectTransform;

    private float _width;
    private float _height;

    [SerializeField]
    private int _gridNum;
    public int GridNum
    {
        get { return _gridNum; }
    }

    private bool[,] _usingGridArray;

    public GameObject[,] BoardObjectArray;

    public Color InitColor;     //最初の色
    private int _targetBoardIndex;


    void Start()
    {
        _width = _rectTransform.sizeDelta.x;
        _height = _rectTransform.sizeDelta.y;
        _usingGridArray = new bool[_gridNum,_gridNum];
        for(int i = 0; i < _gridNum; i++)
        {
            for(int j = 0; j < _gridNum; j++)
            {
                _usingGridArray[i, j] = true;
            }
        }
        _targetBoardIndex = -1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NearestSquareColorChange(Vector3 square)
    {


        var x = NearestNum(square.x, _width);
        var y = NearestNum(square.y, _height);

        if (x.Item2 && y.Item2 && _usingGridArray[x.Item3, y.Item3] &&(x.Item3 + (y.Item3 * _gridNum)) != _targetBoardIndex)
        {
            SquareCororRevert();
            BoardObjectArray[x.Item3, y.Item3].GetComponent<Image>().color = new Color(1.0f, 0.7127465f, 0.7019608f, 1.0f);
            _targetBoardIndex = x.Item3 + (y.Item3 * _gridNum);
        }

        else if(!(x.Item2 && y.Item2) || !(_usingGridArray[x.Item3, y.Item3]))
        {
            SquareCororRevert();
            _targetBoardIndex = -1;

        }
    }

    public void SquareCororRevert()
    {
        if (_targetBoardIndex != -1)
        {
            BoardObjectArray[_targetBoardIndex % _gridNum, _targetBoardIndex / _gridNum].GetComponent<Image>().color = InitColor;
        }
    }

    public (Vector3, bool, int) NearestSquare(Vector3 square)
    {
        Vector3 nearestSquare;
        float nearestX;
        float nearestY;

        var x = NearestNum(square.x, _width);
        var y = NearestNum(square.y, _height);

        if(!(x.Item2 && y.Item2))
        {
            return (Vector3.one, false, -1);
        }

        if(!(_usingGridArray[x.Item3, y.Item3]))
        {
            return (Vector3.one, false, -1);
        }

        _usingGridArray[x.Item3, y.Item3] = false;

        nearestX = x.Item1;
        nearestY = y.Item1;
        Debug.Log("[ " + x.Item3 + ", " + y.Item3 + " ]");

        nearestSquare = new Vector3(nearestX, nearestY, 0);

        return (nearestSquare, true, _targetBoardIndex);
    }

    private (float, bool, int) NearestNum(float num, float orientation)
    {
        
        float edge = -(orientation / 2);
        for (int i = 0; i <  _gridNum; i++)
        {
            if(num >= edge + ((orientation / _gridNum) * i)  && num <= edge + ((orientation / _gridNum) * (i + 1)))
            {
                return (edge + ((orientation / _gridNum)  * (i + 0.5f)), true, i);
            }
        }
        return (0, false, 0);
    }
}
