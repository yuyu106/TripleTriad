using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPanelOpener : MonoBehaviour
{
    [SerializeField]
    private Transform board;

    [SerializeField]
    private OnClickListener _onClick;
    // Start is called before the first frame update
    void Awake()
    {
        _onClick.OnPointerClickCallback = OnClick;
    }

    public void OnClick(GameObject gameObject)
    {
        board.localPosition = new Vector2(-20, 300);
    }
}
