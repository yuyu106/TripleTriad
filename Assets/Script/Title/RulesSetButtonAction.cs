using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RulesSetButtonAction : MonoBehaviour
{
    [SerializeField]
    private bool _isOnButton;

    [SerializeField]
    private SpecialRules _specialRules;

    [SerializeField]
    private Button _thisButton;
    [SerializeField]
    private Button _nextButton;

    [SerializeField]
    private OnClickListener OnClick;

    // Start is called before the first frame update
    void Awake()
    {
        OnClick.OnPointerClickCallback = OnClickCallBack;

        if(SpecialRulesSender.Instance.SettingRuleList[(int)_specialRules] == _isOnButton)
        {
            _thisButton.interactable = false;
        }
        else
        {
            _thisButton.interactable = true;
        }
    }

    public void OnClickCallBack(GameObject gameObject)
    {
        SpecialRulesSender.Instance.SettingRuleList[(int)_specialRules] = _isOnButton;
        _thisButton.interactable = false;
        _nextButton.interactable = true;

    }
}
