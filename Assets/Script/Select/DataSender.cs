using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSender
{

    public CardManager data;

    private static DataSender _instance;

    public static DataSender Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new DataSender();
            }
            return _instance;
        }
    }


}