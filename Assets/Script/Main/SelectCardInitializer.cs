using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/*
 * Select画面で選択されたカードを
 * メイン画面に配置していく
 */ 
public class SelectCardInitializer : MonoBehaviour
{
    //配置するカードの親
    [SerializeField]
    private GameObject _redCards;
    [SerializeField]
    private GameObject _blueCards;

    [SerializeField]
    private CardAction _cardPrefab;



    [SerializeField]
    private GameBoard _gameBoard;
    [SerializeField]
    private GameMaster _gameMaster;

    // Start is called before the first frame update
    void Start()
    {
        CardAction[] cardActions = new CardAction[10];
        for (int i = 0; i < 10; i++)
        {
            CardAction card = new CardAction();
            if(i < 5)
            {
                card = Instantiate(_cardPrefab, _redCards.transform);
                //色と位置
                card.transform.localPosition = new Vector3(-350f, -150f * (i - 2), 0);
                card.ChangeCardColor(TeamColor.RED);

                //データ
                card.CardAttribute = DataSender.Instance.data.GetCardAttributeInSelectCardList(TeamColor.RED, i);
            }
            else
            {
                card = Instantiate(_cardPrefab, _blueCards.transform);
                //色と位置
                card.transform.localPosition = new Vector3(350f, -150f * (i - 2 - 5), 0);
                card.ChangeCardColor(TeamColor.BLUE);
                //データ
                card.CardAttribute = DataSender.Instance.data.GetCardAttributeInSelectCardList(TeamColor.BLUE, i - 5);
            };

            card.Initialize(_gameBoard, _gameMaster);

            //Textセット
            card.CardTextSet();

            //クリックとドラッグ
            card.InvalidClickEvent();
            card.SetOnDragCallback();

            cardActions[i] = card;
        }


        _gameMaster.SetCardsArray(cardActions);

        //赤チームからスタート
        _gameMaster.ChangeSelectableCards(TeamColor.BLUE);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnClickCallback(GameObject gameObject)
    {

    }


}
