using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonAction : MonoBehaviour
{
    [SerializeField]
    private GameObject _cards;
    [SerializeField]
    private OnClickListener _onClickListener;   //クリックしたときに呼ばれるクラス
    [SerializeField]
    private CardManeger _cardManeger;   


    void Start()
    {
        //ボタンを無効にする
        SwichButtonEnable(0);

        //クリックしたときの動作
        _onClickListener.OnPointerClickCallback = OnClickCallback; 
    }

    void Update()
    {
        
    }

    /*
     * クリックしたときの動き
     * red選択画面→blue選択画面
     * blue選択画面→メイン画面
     * 
     */
    private void OnClickCallback(GameObject gameObject)
    {


        if (_cards.GetComponent<CardManeger>().TeamColor == TeamColor.BLUE)
        {
            DataSender.Instance.data.SelectCardListBlue = _cards.GetComponent<CardManeger>().SelectCardListBlue;

            SceneManager.LoadScene("Main");
        }
        else
        {
            DataSender.Instance.data = _cards.GetComponent<CardManeger>();
    
            SceneManager.LoadScene("SelectBlue");
        }
    }

    public void SwichButtonEnable(int selectCardnum)
    {
        if (selectCardnum == 5)
        {
            gameObject.GetComponent<Button>().interactable = true;
        }
        else
        {
            gameObject.GetComponent<Button>().interactable = false;
            Debug.Log("無効");
        }
    }
}
