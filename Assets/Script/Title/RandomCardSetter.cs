using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class RandomCardSetter : MonoBehaviour
{
    [SerializeField]
    private TextAsset _csvFile;

    private List<string[]> _csvDatas = new List<string[]>();

    private int start = 0;
    private int end = 10;

    List<int> numbers;

    [SerializeField]
    private OnClickListener _onClick;

    // Start is called before the first frame update
    void Awake()
    {
        _onClick.OnPointerClickCallback = RandomModeButtonListener;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RandomModeButtonListener(GameObject gameObject)
    {
        //csvにカードの強さ情報入ってるよ
        _csvFile = Resources.Load("CardData") as TextAsset;
        StringReader reader = new StringReader(_csvFile.text);

        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine();
            _csvDatas.Add(line.Split(','));
        }

        DataSender.Instance.data = new CardManager();

        RandomSelectCardsSetter(TeamColor.RED);
        RandomSelectCardsSetter(TeamColor.BLUE);

        SceneManager.LoadScene("main");


    }

    private void RandomSelectCardsSetter(TeamColor teamColor)
    {
        numbers = new List<int>();

        for (int i = start; i < end; i++)
        {
            numbers.Add(i);
        }

        System.Random rnd = new System.Random();

        for (int i = 0; i < 5; i++)
        {
            Debug.Log("Size" + numbers.Count);
            int index = rnd.Next(numbers.Count);
            int num = numbers[index];
            numbers.RemoveAt(index);

            Debug.Log(index);

            CardAttribute cardAttribute = new CardAttribute();
            cardAttribute.Top = int.Parse(_csvDatas[num + 1][0]);
            cardAttribute.Right = int.Parse(_csvDatas[num + 1][1]);
            cardAttribute.Bottom = int.Parse(_csvDatas[num + 1][2]);
            cardAttribute.Left = int.Parse(_csvDatas[num + 1][3]);
            cardAttribute.TeamColor = teamColor;

            DataSender.Instance.data.AddSelectCardList(cardAttribute);

        }
    }
}
