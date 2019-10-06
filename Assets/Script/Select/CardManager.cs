using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{

    [SerializeField]
    TeamColor _teamColor;

    public TeamColor TeamColor
    {
        get
        {
            return _teamColor;
        }
    }
    //全部のカードのデータ持ってる
    private List<CardAttribute> _cardList = new List<CardAttribute>();

    //赤で選択されたカード情報
    private List<CardAttribute> _selectCardListRed = new List<CardAttribute>();
/*    public List<CardAttribute> SelectCardListRed
    {
        get
        {
            return _selectCardListRed;
        }
    }
*/
    //青で追加されたカード情報
    private List<CardAttribute> _selectCardListBlue = new List<CardAttribute>();
/*    private List<CardAttribute> SelectCardListBlue
    {
        get
        {
            return _selectCardListBlue;
        }
    }
*/
    

  
    //対応するリストの指定された値を返す
    public CardAttribute GetCardAttributeInSelectCardList(TeamColor teamColor, int num)
    {
        switch (teamColor)
        {
            case TeamColor.RED:
                return _selectCardListRed[num];
            case TeamColor.BLUE:
                return _selectCardListBlue[num];
            default:
                return null;
        }
    }

    //対応するリストの長さを返す
    public int SelectCardListCount(TeamColor teamColor)
    {
        
        switch (teamColor)
        {
            case TeamColor.RED:
                return _selectCardListRed.Count;
            case TeamColor.BLUE:
                return _selectCardListBlue.Count;
            default:
                return 0;
        }
    }

    //対応するリストに追加
    public void AddSelectCardList(CardAttribute cardAttribute)
    {
        switch (cardAttribute.TeamColor)
        {
            case TeamColor.RED:
                _selectCardListRed.Add(cardAttribute);
                break;
            case TeamColor.BLUE:
                _selectCardListBlue.Add(cardAttribute);
                break;
        }
    }
    public void AddCardList(CardAttribute cardAttribute)
    {
        _cardList.Add(cardAttribute);
    }
    //対応するリストから削除
    public void RemoveSelectCardList(CardAttribute cardAttribute)
    {
        switch (cardAttribute.TeamColor)
        {
            case TeamColor.RED:
                _selectCardListRed.Remove(cardAttribute);
                break;
            case TeamColor.BLUE:
                _selectCardListBlue.Remove(cardAttribute);
                break;
        }
    }


    private void Awake()
    {

    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
