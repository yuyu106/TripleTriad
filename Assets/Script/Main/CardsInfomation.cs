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

        CardAttribute targetCardAttribute = CardActionArray[col, row].GetComponent<CardAction>().CardAttribute;

        //righit
        if (col + 1 < gridNum && CardActionArray[col + 1, row] != null)
        {
            CardAttribute rightCard = CardActionArray[col + 1, row].GetComponent<CardAction>().CardAttribute;


            if (targetCardAttribute.Right > rightCard.Left)
            {

                CardActionArray[col + 1, row].GetComponent<Image>().sprite = rightCard.AnotherImage;
            }
        }

        //left
        if (col - 1 >= 0 && CardActionArray[col - 1, row] != null)
        {
            CardAttribute leftCard = CardActionArray[col - 1, row].GetComponent<CardAction>().CardAttribute;


            if (targetCardAttribute.Right > leftCard.Right)
            {

                CardActionArray[col - 1, row].GetComponent<Image>().sprite = leftCard.AnotherImage;
            }
        }

        //top
        if (row + 1 < gridNum && CardActionArray[col, row + 1] != null)
        {
            CardAttribute topCard = CardActionArray[col, row + 1].GetComponent<CardAction>().CardAttribute;


            if (targetCardAttribute.Top > topCard.Bottom)
            {

                CardActionArray[col, row + 1].GetComponent<Image>().sprite = topCard.AnotherImage;
            }
        }

        //bottom
        if (row -1 >= 0 && CardActionArray[col, row - 1] != null)
        {
            CardAttribute bottomCard = CardActionArray[col, row - 1].GetComponent<CardAction>().CardAttribute;


            if (targetCardAttribute.Bottom > bottomCard.Top)
            {

                CardActionArray[col, row - 1].GetComponent<Image>().sprite = bottomCard.AnotherImage;
            }
        }
    }
}
