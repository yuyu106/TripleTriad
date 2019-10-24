using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    [SerializeField]
    private GameObject _redCards;
    [SerializeField]
    private GameObject _blueCards;
    [SerializeField]
    private Text _redScoreText;
    [SerializeField]
    private Text _blueScoreText;
    [SerializeField]
    private Text _tarnText;
    [SerializeField]
    private RectTransform _tarnBoard;

    private Vector3 _tarnBoardOriginPos;
    private bool _isFirstTarn = true;
    

    [SerializeField]
    private GameBoard _gameBoard;
    [SerializeField]
    private GameBoardInit _gameBoardInit;

    public bool isFripping = false;
    private int _remainingBoard;

    [SerializeField]
    private int _gridNum;
    public int GridNum
    {
        get
        {
            return _gridNum;
        }
    }

    //全てのカード情報
    private CardAction[] _cardsArray;
    public void SetCardsArray(CardAction[] cardActions)
    {
        _cardsArray = cardActions;
    }

    //選択されたカードの情報
    private CardAction[,] _cardAttributeOnTileArray;
    public void AddCardAttributeOnTileArray(int index, CardAction cardAction)
    {
        _cardAttributeOnTileArray[index % _gridNum, index / _gridNum] = cardAction;
    }

    // Start is called before the first frame update
    void Awake()
    {
        _gameBoard.SetGridNum(_gridNum);
        _gameBoardInit.GameBoardInitialize(_gridNum);
        _cardAttributeOnTileArray = new CardAction[_gridNum , _gridNum];
        _tarnBoardOriginPos = _tarnBoard.localPosition;
        _remainingBoard = _gridNum * _gridNum;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //順番交代
    public void ChangeSelectableCards(TeamColor teamColor)
    {
        if (_isFirstTarn == true)
        {
            ScoreTextSetter();
            _isFirstTarn = false;
        }
        else if(_remainingBoard > 1)
        {
            Debug.Log("置ける場所　" + _remainingBoard + "箇所");
            _remainingBoard--;

            foreach (CardAction card in _cardsArray)
            {
                if (card.CardAttribute.TeamColor == teamColor)
                {
                    card.SwichCardDragEnable(false);
                }
                else
                {
                    card.SwichCardDragEnable(true);
                }
            }
            StartCoroutine(TextSetCoRoutine(teamColor));
        }
        else
        {
            StartCoroutine(LoadSceneCoRoutine());
        }
        

    }
    private IEnumerator LoadSceneCoRoutine()
    {
        yield return new WaitWhile(() => isFripping != false);
        ScoreSender score = ScoreSender.Instance;
        ScoreTextSetter();
        score.RedScore = _redScoreText.text;
        score.BlueScore = _blueScoreText.text;

        SceneManager.LoadScene("Result");
    }

    private IEnumerator TextSetCoRoutine(TeamColor teamColor)
    {
        _tarnBoard.DOLocalMoveY(700f, 0.3f)
        .OnComplete(() =>
        {
            if (teamColor == TeamColor.RED)
            {
                _tarnText.text = "2Pのターン";
                _tarnText.color = new Color(0.4f, 0.5180836f, 1, 1);

            }
            else
            {
                _tarnText.text = "1Pのターン";
                _tarnText.color = new Color(1, 0.4009434f, 0.4009434f, 1);
            }

            _tarnBoard.DOLocalMove(_tarnBoardOriginPos, 0.3f);

        });


        yield return new WaitWhile(() => isFripping != false);

        ScoreTextSetter();

        yield break;
        
    }

    private void ScoreTextSetter()
    {
        int redCardNum = 0;
        int blueCardNum = 0;


        foreach (CardAction i in _cardsArray)
        {
            if (i.CardAttribute.TeamColor == TeamColor.RED)
            {
                redCardNum++;
            }
            else
            {
                blueCardNum++;
            }

        }

        _redScoreText.text = redCardNum.ToString();
        _blueScoreText.text = blueCardNum.ToString();
    }

    //隣り合うカードと比較
    public void Compare(int targetCardIndex)
    {
        int row = targetCardIndex / _gridNum;
        int col = targetCardIndex % _gridNum;

        Debug.Log(row + " " + col);

        CardAttribute targetCardAttribute = _cardAttributeOnTileArray[col, row].CardAttribute;

        //righit
        if (col + 1 < _gridNum && _cardAttributeOnTileArray[col + 1, row] != null)
        {
            CardAction rightCard = _cardAttributeOnTileArray[col + 1, row];


            if (targetCardAttribute.Right > rightCard.CardAttribute.Left && targetCardAttribute.TeamColor != rightCard.CardAttribute.TeamColor)
            {
                ChangeNextCardColor(targetCardAttribute, rightCard);
            }
        }

        //left
        if (col - 1 >= 0 && _cardAttributeOnTileArray[col - 1, row] != null)
        {
            CardAction leftCard = _cardAttributeOnTileArray[col - 1, row];


            if (targetCardAttribute.Left > leftCard.CardAttribute.Right && targetCardAttribute.TeamColor != leftCard.CardAttribute.TeamColor)
            {
                ChangeNextCardColor(targetCardAttribute, leftCard);
            }
        }

        //top
        if (row + 1 < _gridNum && _cardAttributeOnTileArray[col, row + 1] != null)
        {
            CardAction topCard = _cardAttributeOnTileArray[col, row + 1];

            if (targetCardAttribute.Top > topCard.CardAttribute. Bottom && targetCardAttribute.TeamColor != topCard.CardAttribute.TeamColor)
            {

                ChangeNextCardColor(targetCardAttribute, topCard);
            }
        }

        //bottom
        if (row - 1 >= 0 && _cardAttributeOnTileArray[col, row - 1] != null)
        {
            CardAction bottomCard = _cardAttributeOnTileArray[col, row - 1];


            if (targetCardAttribute.Bottom > bottomCard.CardAttribute.Top && targetCardAttribute.TeamColor != bottomCard.CardAttribute.TeamColor)
            {
                ChangeNextCardColor(targetCardAttribute, bottomCard);
            }
        }

    }

    private void ChangeNextCardColor(CardAttribute target , CardAction next)
    {
        isFripping = true;
        next.FripCard(target.TeamColor);

        next.CardAttribute.TeamColor = target.TeamColor;
    }
}
