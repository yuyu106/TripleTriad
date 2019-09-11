using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAction : MonoBehaviour
{
    [SerializeField]
    GameObject gameBoard;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<DragObject>().OnEndDragCallback = OnEndDragCard;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void  OnEndDragCard()
    {
        RectTransform rectTransform = gameObject.GetComponent<DragObject>().RectTransform;
        Vector3 originalPosition = gameObject.GetComponent<DragObject>().OriginalPosition;

        var position = gameBoard.GetComponent<GameBoard>().NearestSquare(rectTransform.localPosition);

        if (position.Item2)
        {
            rectTransform.localPosition = position.Item1;
            gameObject.GetComponent<DragObject>().enabled = false;
        }
        else
        {
            rectTransform.localPosition = originalPosition;
        }
    }
}
