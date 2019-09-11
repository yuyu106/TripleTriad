using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragObject : MonoBehaviour,IDragHandler, IEndDragHandler, IBeginDragHandler
{
    [SerializeField]
    private  RectTransform _rectTransform;
    public RectTransform RectTransform
    {
        get { return _rectTransform; }
    }

    private Vector3 _originalPosition;
    public Vector3 OriginalPosition
    {
        get { return _originalPosition; }
    }

    public Action OnEndDragCallback;


    public void OnBeginDrag(PointerEventData eventData)
    {
        _originalPosition = _rectTransform.localPosition;
    }

   public void OnDrag(PointerEventData eventData)
    {
          _rectTransform.localPosition += new Vector3(eventData.delta.x, eventData.delta.y, 0f);
//        gameObject.GetComponent<RectTransform>().position += new Vector3(e.delta.x, e.delta.y, 0f);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        OnEndDragCallback.Invoke();


        
    }
}
