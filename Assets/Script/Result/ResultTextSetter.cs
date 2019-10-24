using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultTextSetter : MonoBehaviour
{
    [SerializeField]
    private Text _redScore;
    [SerializeField]
    private Text _blueScore;
    [SerializeField]
    private Text _winnerText;

    [SerializeField]
    private Color _red;
    [SerializeField]
    private Color _blue;
    [SerializeField]
    private Color _black;
    // Start is called before the first frame update
    void Awake()
    {
        ScoreSender score = ScoreSender.Instance;
        _redScore.text = score.RedScore;
        _blueScore.text = score.BlueScore;

        if(int.Parse(score.RedScore) > int.Parse(score.BlueScore))
        {
            _winnerText.text = "1Pの勝ち！";
            _winnerText.color = _red;
        }
        else if (int.Parse(score.RedScore) == int.Parse(score.BlueScore))
        {
            _winnerText.text = "引き分け！";
            _winnerText.color = _black;
        }
        else
        {
            Debug.Log("2P WIN");
            _winnerText.text = "2Pの勝ち！";
            _winnerText.color = _blue;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
