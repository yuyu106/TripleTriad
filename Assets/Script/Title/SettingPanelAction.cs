using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SettingPanelAction : MonoBehaviour
{
    [SerializeField]
    private RectTransform _rectTransform;

    [SerializeField]
    private OnClickListener _onClickListener;

    private bool Showing;
    private Sequence seq;

    // Start is called before the first frame update
    void Awake()
    {
        _onClickListener.OnPointerClickCallback = OnClickCallback;
        OnClickCallback(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnClickCallback(GameObject gameObject)
    {
        if (Showing != true)
        {
            Showing = true;

            seq = DOTween.Sequence();


            seq.Append(
                _rectTransform.DOLocalMoveY(30f, 1f).SetEase(Ease.OutBounce)
            );

            seq.Append(
                _rectTransform.DOLocalMoveY(500, 0.5f).SetDelay(2.0f)
            )
            .AppendCallback(() =>
            {
                Showing = false;
            });
        }

        else
        {
            _rectTransform.DOLocalMoveY(500, 0.5f)
                .OnComplete(() => 
                {
                     Showing = false;
                });
        }

    }
}
