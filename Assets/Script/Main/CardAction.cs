using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAction : MonoBehaviour
{
    public GameObject GameBoard;
    public GameObject Cards;

    public CardAttribute CardAttribute;

    private int cardIndex;
    [SerializeField]
    private DragObject dragObject;

    // Start is called before the first frame update
    void Awake()
    {
        /*
                gameObject.GetComponent<DragObject>().OnEndDragCallback = OnEndDragCard;
                gameObject.GetComponent<DragObject>().OnDragCallback = OnDragCard;
                CardAttribute = new CardAttribute();
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void  OnEndDragCard(GameObject gameObject)
    {
        TeamColor teamColor = gameObject.GetComponent<CardAction>().CardAttribute.TeamColor;
        RectTransform rectTransform = gameObject.GetComponent<DragObject>().RectTransform;
        Vector3 originalPosition = gameObject.GetComponent<DragObject>().OriginalPosition;

        var position = GameBoard.GetComponent<GameBoard>().NearestSquare(rectTransform.localPosition);

        if (position.Item2)
        {
            rectTransform.localPosition = position.Item1;
            gameObject.GetComponent<DragObject>().enabled = false;

            int gridNum = GameBoard.GetComponent<GameBoard>().GridNum;
            cardIndex = position.Item3;

            Debug.Log(cardIndex);
            Cards.GetComponent<CardsInfomation>().CardActionArray[position.Item3 % gridNum, position.Item3 / gridNum] = gameObject;
            Debug.Log(Cards.GetComponent<CardsInfomation>().CardActionArray[position.Item3 % gridNum, position.Item3 / gridNum].GetComponent<CardAction>().cardIndex);

            Debug.Log(position.Item3 % gridNum + " " + position.Item3 / gridNum);

            //隣と比べたりする
            Cards.GetComponent<CardsInfomation>().Compare(cardIndex);
            GameBoard.GetComponent<GameMaster>().ChangeSelectableCards(teamColor);


        }
        else
        {
            rectTransform.localPosition = originalPosition;
        }

        GameBoard.GetComponent<GameBoard>().SquareCororRevert();
    }

    public void OnDragCard(GameObject gameObject)
    {
        RectTransform rectTransform = gameObject.GetComponent<DragObject>().RectTransform;
        GameBoard.GetComponent<GameBoard>().NearestSquareColorChange(rectTransform.localPosition);
    }

    public void SwichCardDragEnable(bool swich)
    {
        if (swich)
        {
            dragObject.enabled = true;
        }
        else
        {
            dragObject.enabled = false;
        }
    }
}
