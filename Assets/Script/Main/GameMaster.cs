using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    [SerializeField]
    private GameObject _redCards;
    [SerializeField]
    private GameObject _blueCards;
    [SerializeField]
    private Text _redScoreText;
    [SerializeField]
    private Text _blueScoreText;

    public CardAction[] CardsArray = new CardAction[10];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSelectableCards(TeamColor teamColor)
    {
         foreach (CardAction i in CardsArray)
         {
            if (i.CardAttribute.TeamColor == teamColor)
            {
                i.SwichCardDragEnable(false);
            }
            else
            {
                i.SwichCardDragEnable(true);
            }
          }

        ScoreTextSetter();

    }

    private void ScoreTextSetter()
    {
        int redCardNum = 0;
        int blueCardNum = 0;


        foreach (CardAction i in CardsArray)
        {
            if (i.CardAttribute.TeamColor == TeamColor.RED)
            {
                redCardNum++;
            }
            else
            {
                blueCardNum++;
            }

        }

        _redScoreText.text = redCardNum.ToString();
        _blueScoreText.text = blueCardNum.ToString();
    }
}
