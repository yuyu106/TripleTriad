using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardAction : MonoBehaviour
{
    private GameBoard _gameBoard;
    private GameMaster _gameMaster;
    private CardManager _cardManager;

    [SerializeField]
    private ButtonAction _buttonAction;
    [SerializeField]
    private EventTrigger _event;
    [SerializeField]
    private OnClickListener _onClickListener;

    public CardAttribute CardAttribute;

    public bool IsSelect;

    private int cardIndex;

    [SerializeField]
    private DragObject _dragObject;
    [SerializeField]
    private CardAction _cardAction;




    //カードに引っ付いてるテキスト
    [SerializeField]
    private Text _topText;
    [SerializeField]
    private Text _righitText;
    [SerializeField]
    private Text _bottomText;
    [SerializeField]
    private Text _leftText;

    //カードの色
    [SerializeField]
    private Image _cardImage;


    //コンポーネント色々設定する
    public void Initialize(CardManager cardManager)
    {
        _cardManager = cardManager;
    }
    public void Initialize(GameBoard gameBoard, GameMaster gameMaster)
    {
        _gameBoard = gameBoard;
        _gameMaster = gameMaster;
    }


    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /*
     * メイン画面用
     * カードのドラッグが終わったとき
     * タイル上にいい感じに置くのと隣との大きさ比べする
     */
    public void OnEndDragCard(GameObject gameObject)
    {
        //ドラッグしたカードのチーム
        TeamColor teamColor = _cardAction.CardAttribute.TeamColor;

        RectTransform rectTransform = _dragObject.RectTransform;
        Vector3 originalPosition = _dragObject.OriginalPosition;

        /*
         * 今いる場所を渡すと近いタイルの場所を教えてくれる
         * Item1 : カードを置くタイルのposition
         * Item2 : true → Item1のタイル上に置く　false → 元の場所に戻す
         * Item3 : カードを置いたタイルのIndex
         */
        var position = _gameBoard.NearestSquare(rectTransform.localPosition);

        //近くのタイルの上にカードを置く
        if (position.Item2)
        {
            //置いた
            rectTransform.localPosition = position.Item1;
            //Drag無効にするのでこの子はもう二度と動けない
            _dragObject.enabled = false;

            //gridNum * gridNum = タイルの数 (正方形とします)
            int gridNum = _gameBoard.GridNum;
            cardIndex = position.Item3;

            //タイルと対応する番号に情報入れてあげる
            _gameMaster.CardAttributeOnTileArray[position.Item3 % gridNum, position.Item3 / gridNum] = CardAttribute;
            Debug.Log(_gameMaster.CardAttributeOnTileArray[position.Item3 % gridNum, position.Item3 / gridNum]);

            //隣と比べたりする
            _gameMaster.Compare(cardIndex);
            //プレイヤー交代
            _gameMaster.ChangeSelectableCards(teamColor);

        }
        else
        {
            rectTransform.localPosition = originalPosition;
        }

        //drag中タイルの色変えてたから元に戻してあげる
        _gameBoard.SquareCororRevert();
    }

    public void OnDragCard(GameObject gameObject)
    {
        RectTransform rectTransform = gameObject.GetComponent<DragObject>().RectTransform;
        //下にあるタイルの色変える
        _gameBoard.NearestSquareColorChange(rectTransform.localPosition);
    }

    //プレイヤー交代の時呼ばれるやつ
    public void SwichCardDragEnable(bool swich)
    {
        if (swich)
        {
            _dragObject.enabled = true;
        }
        else
        {
            _dragObject.enabled = false;
        }
    }

    //テキストに値をセット
    public void CardTextSet()
    {
        _topText.text = CardAttribute.Top.ToString();
        _righitText.text = CardAttribute.Right.ToString();
        _bottomText.text = CardAttribute.Bottom.ToString();
        _leftText.text = CardAttribute.Left.ToString();
    }

    //DragObjectにCallback設定する
    public void SetOnDragCallback()
    {
        _dragObject.OnDragCallback = OnDragCard;
        _dragObject.OnEndDragCallback = OnEndDragCard;
    }

    //ClickのCallback
    public void OnPointerClickCallback(GameObject gameObject)
    {
        if (IsSelect == true)
        {
            Debug.Log("isSelect = true");
            //選択解除なので真っ白にする
            _cardImage.color = new Color(1f, 1f, 1f, 1f);
            //選択されたカードを選択リストから消す
            _cardManager.RemoveSelectCardList(CardAttribute);

            IsSelect = false;
        }
        //５枚までしか選択できない
        else if (_cardManager.SelectCardListCount(CardAttribute.TeamColor) < 5)           
        {
            Debug.Log("isSelect = false");

            //選択済み
            IsSelect = true;

            if (CardAttribute.TeamColor == TeamColor.RED)
            {
                _cardImage.color = new Color(1f, 0.4009434f, 0.4009434f, 1f);
            }
            else
            {
                _cardImage.color = new Color(0.4f, 0.5180836f, 1f, 1f);
            }
            //選択済みリストに追加
            _cardManager.AddSelectCardList(CardAttribute);

        }
        //選択中が5枚だったらボタン有効にしてくれるやつ
        _buttonAction.SwichButtonEnable(_cardManager.SelectCardListCount(CardAttribute.TeamColor));

    }

    //クリックにCallbackを設定
    public void SetOnClickCallback()
    {
        _onClickListener.OnPointerClickCallback = OnPointerClickCallback;
    }
    //クリック無効
    public void InvalidClickEvent()
    {
        _event.enabled = false;
    }


}
