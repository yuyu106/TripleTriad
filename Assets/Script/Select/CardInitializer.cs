using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class CardInitializer : MonoBehaviour
{
    [SerializeField]
    private GameObject _cardsObject;
    [SerializeField]
    private GameObject _cardPrefab;


    private TextAsset _csvFile;
    private List<string[]> _csvDatas = new List<string[]>();

    private static int _cardNum = 10;

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
            GameObject card = Instantiate(_cardPrefab, _cardsObject.transform);
            CardAttribute cardAttribute = card.GetComponent<CardData>().CardAttribute;

            Debug.Log("string " + _csvDatas[i][0]);
            Debug.Log("int " + int.Parse(_csvDatas[i][0]));
            cardAttribute.Top = int.Parse(_csvDatas[i][0]);

            cardAttribute.Right = int.Parse(_csvDatas[i][1]);
            cardAttribute.Bottom = int.Parse(_csvDatas[i][2]);
            cardAttribute.Left = int.Parse(_csvDatas[i][3]);

            card.GetComponent<CardData>().TextSet();

            _cardsObject.GetComponent<CardManeger>().CardList.Add(card);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
