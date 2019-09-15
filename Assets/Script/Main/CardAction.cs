using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAction : MonoBehaviour
{
    [SerializeField]
    private GameObject _gameBoard;
    [SerializeField]
    private GameObject _cards;

    public CardAttribute CardAttribute;

    private int cardIndex;


    // Start is called before the first frame update
    void Awake()
    {
        gameObject.GetComponent<DragObject>().OnEndDragCallback = OnEndDragCard;
        gameObject.GetComponent<DragObject>().OnDragCallback = OnDragCard;
        CardAttribute = new CardAttribute();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void  OnEndDragCard()
    {
        RectTransform rectTransform = gameObject.GetComponent<DragObject>().RectTransform;
        Vector3 originalPosition = gameObject.GetComponent<DragObject>().OriginalPosition;

        var position = _gameBoard.GetComponent<GameBoard>().NearestSquare(rectTransform.localPosition);

        if (position.Item2)
        {
            rectTransform.localPosition = position.Item1;
            gameObject.GetComponent<DragObject>().enabled = false;

            int gridNum = _gameBoard.GetComponent<GameBoard>().GridNum;
            _cards.GetComponent<CardsInfomation>().CardActionArray[position.Item3 % gridNum, position.Item3 / gridNum] = gameObject;
            cardIndex = position.Item3;

            //隣と比べたりする
            _cards.GetComponent<CardsInfomation>().Compare(cardIndex);


        }
        else
        {
            rectTransform.localPosition = originalPosition;
        }

        _gameBoard.GetComponent<GameBoard>().SquareCororRevert();
    }

    private void OnDragCard()
    {
        RectTransform rectTransform = gameObject.GetComponent<DragObject>().RectTransform;
        _gameBoard.GetComponent<GameBoard>().NearestSquareColorChange(rectTransform.localPosition);
    }
}
