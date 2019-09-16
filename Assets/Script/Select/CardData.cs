using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardData : MonoBehaviour
{
    [SerializeField]
    private Text _topText;
    [SerializeField]
    private Text _righitText;
    [SerializeField]
    private Text _bottomText;
    [SerializeField]
    private Text _leftText;

    public CardAttribute CardAttribute = new CardAttribute();

    public bool isSelect;

    private int cardIndex;


    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TextSet()
    {
        _topText.text = CardAttribute.Top.ToString();
        _righitText.text = CardAttribute.Right.ToString();
        _bottomText.text = CardAttribute.Bottom.ToString();
        _leftText.text = CardAttribute.Left.ToString();
    }

}
