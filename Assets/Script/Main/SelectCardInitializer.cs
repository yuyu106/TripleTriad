using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectCardInitializer : MonoBehaviour
{
    [SerializeField]
    private GameObject _redCards;
    [SerializeField]
    private GameObject _blueCards;
    [SerializeField]
    private GameObject _cardPrefab;
    [SerializeField]
    private GameObject _gameBoard;

    // Start is called before the first frame update
    void Start()
    {
        CardAction[] component = new CardAction[10];
        for (int i = 0; i < 5; i++)
        {
            GameObject card = Instantiate(_cardPrefab, _redCards.transform);
            card.transform.localPosition = new Vector3(-350f, -150f * (i - 2), 0);
            card.GetComponent<Image>().color = new Color(1f, 0.4009434f, 0.4009434f, 1f);
            card.GetComponent<CardData>().CardAttribute = DataSender.Instance.data.SelectCardListRed[i];
            card.GetComponent<CardAction>().CardAttribute = DataSender.Instance.data.SelectCardListRed[i];
            card.GetComponent<CardData>().TextSet();
            card.GetComponent<CardAction>().GameBoard = _gameBoard;
            card.GetComponent<CardAction>().Cards = _redCards;
            card.GetComponent<OnClickListener>().OnPointerClickCallback = OnClickCallback;
            card.GetComponent<DragObject>().OnEndDragCallback = card.GetComponent<CardAction>().OnEndDragCard;
            card.GetComponent<DragObject>().OnDragCallback = card.GetComponent<CardAction>().OnDragCard;
            component[i] = card.GetComponent<CardAction>();
        }

        for (int i = 0; i < 5; i++)
        {
            GameObject card = Instantiate(_cardPrefab, _blueCards.transform);
            card.transform.localPosition = new Vector3(350f, -150f * (i - 2), 0);
            card.GetComponent<Image>().color = new Color(0.4f, 0.5180836f, 1f, 1f);
            card.GetComponent<CardData>().CardAttribute = DataSender.Instance.data.SelectCardListBlue[i];
            card.GetComponent<CardAction>().CardAttribute = DataSender.Instance.data.SelectCardListBlue[i];
            card.GetComponent<CardData>().TextSet();
            card.GetComponent<CardAction>().GameBoard = _gameBoard;
            card.GetComponent<CardAction>().Cards = _redCards;
            card.GetComponent<OnClickListener>().OnPointerClickCallback = OnClickCallback;
            card.GetComponent<DragObject>().OnEndDragCallback = card.GetComponent<CardAction>().OnEndDragCard;
            card.GetComponent<DragObject>().OnDragCallback = card.GetComponent<CardAction>().OnDragCard;
            component[i + 5] = card.GetComponent<CardAction>();
        }

        _gameBoard.GetComponent<GameMaster>().CardsArray = component;
        _gameBoard.GetComponent<GameMaster>().ChangeSelectableCards(TeamColor.BLUE);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnClickCallback(GameObject gameObject)
    {

    }


}
