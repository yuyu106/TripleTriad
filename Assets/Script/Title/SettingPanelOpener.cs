using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SettingPanelOpener : MonoBehaviour
{
    [SerializeField]
    private Transform board;

    [SerializeField]
    private OnClickListener _onClick;

    private bool Showing;

    // Start is called before the first frame update
    void Awake()
    {
        _onClick.OnPointerClickCallback = OnClick;
    }

    public void OnClick(GameObject gameObject)
    {
        if (Showing != true)
        {
            Showing = true;
            board.DOLocalMoveY(0f, 1f).SetEase(Ease.OutBounce);
        }

        else
        {
            Showing = false;
            board.DOLocalMoveY(750, 0.5f);                
        }

    }
}
