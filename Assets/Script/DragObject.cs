using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragObject : MonoBehaviour,IDragHandler, IEndDragHandler, IBeginDragHandler
{
    [SerializeField]
    private RectTransform rectTransform;

    [SerializeField]
    private GameObject gameBoard;

    private Vector3 originalPosition;

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalPosition = rectTransform.localPosition;
    }

   public void OnDrag(PointerEventData eventData)
    {
          rectTransform.localPosition += new Vector3(eventData.delta.x, eventData.delta.y, 0f);
//        gameObject.GetComponent<RectTransform>().position += new Vector3(e.delta.x, e.delta.y, 0f);
    }

    public void OnEndDrag(PointerEventData eventData)
    { 
        var position = gameBoard.GetComponent<GameBoard>().NearestSquare(rectTransform.localPosition);

        if (position.Item2)
        {
            rectTransform.localPosition = position.Item1;
        }
        else
        {
            rectTransform.localPosition = originalPosition;
        }
        
    }
}
