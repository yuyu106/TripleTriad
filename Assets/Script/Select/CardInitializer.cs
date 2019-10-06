using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardInitializer : MonoBehaviour
{
    [SerializeField]
    private GameObject _cardsObject;
    [SerializeField]
    private CardAction _cardPrefab;
    [SerializeField]
    private CardManager _cardManager;
    [SerializeField]
    private ButtonAction _buttonAction;




    private TextAsset _csvFile;
    private List<string[]> _csvDatas = new List<string[]>();

    //並べるカードの枚数
    private int _cardNum = 10;

    private CardAction _cardAction;


    // Start is called before the first frame update
    void Start()
    {
        //csvにカードの強さ情報入ってるよ
        _csvFile = Resources.Load("CardData") as TextAsset;
        StringReader reader = new StringReader(_csvFile.text);

        while(reader.Peek() != -1)
        {
            string line = reader.ReadLine();
            _csvDatas.Add(line.Split(','));
        }

        for(int i = 1; i <= _cardNum; i++)
        {
            // select画面のカード生む
            _cardAction = Instantiate<CardAction>(_cardPrefab, _cardsObject.transform);
            CardAttribute cardAttribute = _cardAction.CardAttribute;

            //強さとTextセット
            cardAttribute.Top = int.Parse(_csvDatas[i][0]);
            cardAttribute.Right = int.Parse(_csvDatas[i][1]);
            cardAttribute.Bottom = int.Parse(_csvDatas[i][2]);
            cardAttribute.Left = int.Parse(_csvDatas[i][3]);
            _cardAction.CardTextSet();

            //チームカラー
            _cardAction.CardAttribute.TeamColor = _cardManager.TeamColor;

            //まだ選択されてない
            _cardAction.IsSelect = false;

            _cardAction.Initialize(_cardManager, _buttonAction);

            //クリックとドラッグ
            _cardAction.SetOnClickCallback();
            _cardAction.SwichCardDragEnable(false);

            _cardManager.AddCardList(_cardAction.CardAttribute);


        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }



}
