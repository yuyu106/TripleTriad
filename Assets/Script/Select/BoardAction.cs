using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BoardAction : MonoBehaviour
{
    [SerializeField]
    private RectTransform _rectTransform;
    [SerializeField]
    private Text _playerText;
    [SerializeField]
    private CardManager _cardManager;
    [SerializeField]
    private OnClickListener _onClickListener;

    private bool Showing;
    private Sequence seq;

    // Start is called before the first frame update
    void Start()
    {
        SetPlayerText(_cardManager.TeamColor);
        Showing = false;

        _onClickListener.OnPointerClickCallback = OnClickCallback;
        OnClickCallback(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetPlayerText(TeamColor teamColor)
    {
 
        switch (teamColor)
        {
            case TeamColor.RED:
                _playerText.color = new Color(1f, 0.414074f, 0.259434f, 1f);
                _playerText.text = "1P";
                break;

            case TeamColor.BLUE:
                _playerText.color = new Color(0.4f, 0.5180836f, 1f, 1f);
                _playerText.text = "2P";
                break;

            default:
                break;
        }
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
