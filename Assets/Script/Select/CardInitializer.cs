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
    private GameObject _cardPrefab;
    [SerializeField]
    private ButtonAction _buttonAction;

    private TextAsset _csvFile;
    private List<string[]> _csvDatas = new List<string[]>();

    private static int _cardNum = 10;

    private GameObject card;

    [SerializeField]
    private TeamColor _teamColor;

    // Start is called before the first frame update
    void Start()
    {
        _csvFile = Resources.Load("CardData") as TextAsset;
        StringReader reader = new StringReader(_csvFile.text);

        while(reader.Peek() != -1)
        {
            string line = reader.ReadLine();
            _csvDatas.Add(line.Split(','));
        }

        for(int i = 1; i <= _cardNum; i++)
        {
            card = Instantiate(_cardPrefab, _cardsObject.transform);
            CardAttribute cardAttribute = card.GetComponent<CardData>().CardAttribute;

//            Debug.Log("string " + _csvDatas[i][0]);
//            Debug.Log("int " + int.Parse(_csvDatas[i][0]));
            cardAttribute.Top = int.Parse(_csvDatas[i][0]);
            cardAttribute.Right = int.Parse(_csvDatas[i][1]);
            cardAttribute.Bottom = int.Parse(_csvDatas[i][2]);
            cardAttribute.Left = int.Parse(_csvDatas[i][3]);

            card.GetComponent<CardData>().TextSet();

            card.GetComponent<CardData>().isSelect = false;
            card.GetComponent<OnClickListener>().OnPointerClickCallback = OnPointerClickCallback;
            //            card.GetComponent<DragObject>().OnDragCallback = OnDragCallback;
            //            card.GetComponent<DragObject>().OnEndDragCallback = OnDragCallback;
            card.GetComponent<DragObject>().enabled = false;
            card.GetComponent<CardData>().CardAttribute.TeamColor = _teamColor;


            _cardsObject.GetComponent<CardManeger>().CardList.Add(card);

        }

        _cardsObject.GetComponent<CardManeger>().TeamColor = _teamColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnPointerClickCallback(GameObject gameObject)
    {
        bool isSelect = gameObject.GetComponent<CardData>().isSelect;

        if (isSelect == true)
        {
            Debug.Log("isSelect = true");
            //           gameObject.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            gameObject.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);

            if (gameObject.GetComponent<CardData>().CardAttribute.TeamColor == TeamColor.RED)
            {
                _cardsObject.GetComponent<CardManeger>().SelectCardListRed.Remove(gameObject.GetComponent<CardData>().CardAttribute);
            }
            else
            {
                _cardsObject.GetComponent<CardManeger>().SelectCardListBlue.Remove(gameObject.GetComponent<CardData>().CardAttribute);
            }
            gameObject.GetComponent<CardData>().isSelect = false;
        }
        else if((gameObject.GetComponent<CardData>().CardAttribute.TeamColor == TeamColor.RED && _cardsObject.GetComponent<CardManeger>().SelectCardListRed.Count < 5)
            || (gameObject.GetComponent<CardData>().CardAttribute.TeamColor == TeamColor.BLUE && _cardsObject.GetComponent<CardManeger>().SelectCardListBlue.Count < 5))
        {
            Debug.Log("isSelect = false");
            //            gameObject.transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
            gameObject.GetComponent<CardData>().isSelect = true;

            if (gameObject.GetComponent<CardData>().CardAttribute.TeamColor == TeamColor.RED)
            {
                gameObject.GetComponent<Image>().color = new Color(1f, 0.4009434f, 0.4009434f, 1f);
                _cardsObject.GetComponent<CardManeger>().SelectCardListRed.Add(gameObject.GetComponent<CardData>().CardAttribute);
            }

            else
            {
                gameObject.GetComponent<Image>().color = new Color(0.4f, 0.5180836f, 1f, 1f);
                _cardsObject.GetComponent<CardManeger>().SelectCardListBlue.Add(gameObject.GetComponent<CardData>().CardAttribute);
            }

            if (gameObject.GetComponent<CardData>().CardAttribute.TeamColor == TeamColor.RED)
            {
                Debug.Log(_cardsObject.GetComponent<CardManeger>().SelectCardListRed.Count);
                _buttonAction.SwichButtonEnable(_cardsObject.GetComponent<CardManeger>().SelectCardListRed.Count);
            }
            else
            {
                _buttonAction.SwichButtonEnable(_cardsObject.GetComponent<CardManeger>().SelectCardListBlue.Count);
            }
            Debug.Log(isSelect);

        }
        
    }

}
