using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultButtonSetter : MonoBehaviour
{
    [SerializeField]
    private OnClickListener _toSelect;
    [SerializeField]
    private RandomCardSetter _random;
    [SerializeField]
    private OnClickListener _toTitle;

    // Start is called before the first frame update
    void Awake()
    {
        if(SpecialRulesSender.Instance.SettingRuleList[(int)SpecialRules.RANDOM] != true){
            _toSelect.OnPointerClickCallback = ToSelectScreen;
            _random.enabled = false;
        }
        else
        {
            _random.enabled = true;
        }
        
        _toTitle.OnPointerClickCallback = ToTitleScreen;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToSelectScreen(GameObject game)
    {

        SceneManager.LoadScene("SelectRed");
    }

    public void ToTitleScreen(GameObject game)
    {
        SceneManager.LoadScene("Title");
    }

}
