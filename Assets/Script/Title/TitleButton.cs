using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButton : MonoBehaviour
{
    [SerializeField]
    private OnClickListener _clickListener;
    // Start is called before the first frame update
    void Start()
    {
        _clickListener.OnPointerClickCallback = OnClickCallback;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickCallback(GameObject game)
    {
        //ランダムモード解除
        SpecialRulesSender.Instance.SettingRuleList[(int)SpecialRules.RANDOM] =　false;
        SceneManager.LoadScene("SelectRed");
    }
}
