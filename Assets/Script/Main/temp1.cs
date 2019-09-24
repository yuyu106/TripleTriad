using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class temp1 : MonoBehaviour
{
    [SerializeField]
    private Sprite image;
    // Start is called before the first frame update
    void Start()
    {
        CardAttribute cardAttribute = gameObject.GetComponent<CardAction>().CardAttribute;
        cardAttribute.Right = 1;
        cardAttribute.Left = 1;
        cardAttribute.Top = 1;
        cardAttribute.Bottom = 1;

        cardAttribute.TeamColor = TeamColor.BLUE;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
