using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManeger : MonoBehaviour
{
    //全部のカードのデータ持ってる
    private List<GameObject> CardList;

    //赤で選択されたカード情報
    private List<CardAttribute> _selectCardListRed = new List<CardAttribute>();
    public List<CardAttribute> SelectCardListRed
    {
        get
        {
            return _selectCardListRed;
        }
    }

    //青で追加されたカード情報
    private List<CardAttribute> _selectCardListBlue = new List<CardAttribute>();
    private List<CardAttribute> SelectCardListBlue
    {
        get
        {
            return _selectCardListBlue;
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
    public void AddSelectCardList(TeamColor teamColor, CardAttribute cardAttribute)
    {
        switch (teamColor)
        {
            case TeamColor.RED:
                _selectCardListRed.Add(cardAttribute);
                break;
            case TeamColor.BLUE:
                _selectCardListBlue.Add(cardAttribute);
                break;
        }
    }
    //対応するリストから削除
    public void RemoveSelectCardList(TeamColor teamColor, CardAttribute cardAttribute)
    {
        switch (teamColor)
        {
            case TeamColor.RED:
                _selectCardListRed.Remove(cardAttribute);
                break;
            case TeamColor.BLUE:
                _selectCardListBlue.Remove(cardAttribute);
                break;
        }
    }

    private TeamColor _teamColor;
    public TeamColor TeamColor
    {
        get
        {
            return _teamColor;
        }
        set
        {
            _teamColor = value; 
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
