using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class temp2 : MonoBehaviour
{
    [SerializeField]
    private Sprite image2;

    // Start is called before the first frame update
    void Start()
    {
        CardAttribute cardAttribute = gameObject.GetComponent<CardAction>().CardAttribute;
        cardAttribute.Right = 2;
        cardAttribute.Left = 2;
        cardAttribute.Top = 2;
        cardAttribute.Bottom = 2;
        cardAttribute.AnotherImage = image2;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
