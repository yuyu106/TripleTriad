using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardsInfomation : MonoBehaviour
{
    public GameObject[,] CardActionArray;

    [SerializeField]
    private GameObject GameBoard;

    private int gridNum;
    // Start is called before the first frame update
    void Start()
    {
        gridNum = GameBoard.GetComponent<GameBoard>().GridNum;

        CardActionArray = new GameObject[gridNum, gridNum];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Compare(int targetCardIndex)
    {
        int row = targetCardIndex / gridNum;
        int col = targetCardIndex % gridNum;

        Debug.Log(row + " " + col);

        CardAttribute targetCardAttribute = CardActionArray[col, row].GetComponent<CardAction>().CardAttribute;
        Color targetColor = CardActionArray[col, row].GetComponent<Image>().color;

        //righit
        if (col + 1 < gridNum && CardActionArray[col + 1, row] != null)
        {
            CardAttribute rightCard = CardActionArray[col + 1, row].GetComponent<CardAction>().CardAttribute;


            if (targetCardAttribute.Right > rightCard.Left && targetCardAttribute.TeamColor != rightCard.TeamColor)
            {

                CardActionArray[col + 1, row].GetComponent<Image>().color = targetColor;
                CardActionArray[col + 1, row].GetComponent<CardAction>().CardAttribute.TeamColor = targetCardAttribute.TeamColor;
            }
        }

        //left
        if (col - 1 >= 0 && CardActionArray[col - 1, row] != null)
        {
            CardAttribute leftCard = CardActionArray[col - 1, row].GetComponent<CardAction>().CardAttribute;


            if (targetCardAttribute.Left > leftCard.Right && targetCardAttribute.TeamColor != leftCard.TeamColor)
            {

                CardActionArray[col - 1, row].GetComponent<Image>().color = targetColor;
                CardActionArray[col - 1, row].GetComponent<CardAction>().CardAttribute.TeamColor = targetCardAttribute.TeamColor;
            }
        }

        //top
        if (row + 1 < gridNum && CardActionArray[col, row + 1] != null)
        {
            CardAttribute topCard = CardActionArray[col, row + 1].GetComponent<CardAction>().CardAttribute;

            Debug.Log(targetCardAttribute.Top);
            if (targetCardAttribute.Top > topCard.Bottom && targetCardAttribute.TeamColor != topCard.TeamColor)
            {

               CardActionArray[col, row + 1].GetComponent<Image>().color = targetColor;
                CardActionArray[col, row + 1].GetComponent<CardAction>().CardAttribute.TeamColor = targetCardAttribute.TeamColor;
            }
        }

        //bottom
        if (row -1 >= 0 && CardActionArray[col, row - 1] != null)
        {
            CardAttribute bottomCard = CardActionArray[col, row - 1].GetComponent<CardAction>().CardAttribute;


            if (targetCardAttribute.Bottom > bottomCard.Top && targetCardAttribute.TeamColor != bottomCard.TeamColor)
            {

                CardActionArray[col, row - 1].GetComponent<Image>().color = targetColor;
                CardActionArray[col, row - 1].GetComponent<CardAction>().CardAttribute.TeamColor = targetCardAttribute.TeamColor;
            }
        }
    }
}
