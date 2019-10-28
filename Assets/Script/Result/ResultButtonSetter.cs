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
    private OnClickListener _toTitle;

    // Start is called before the first frame update
    void Awake()
    {
        _toSelect.OnPointerClickCallback = ToSelectScreen;
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
