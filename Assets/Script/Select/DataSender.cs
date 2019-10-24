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

public class ScoreSender
{
    public string RedScore;
    public string BlueScore;

    private static ScoreSender _instance;
    public static ScoreSender Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ScoreSender();
            }
            return _instance;
        }
    }
}