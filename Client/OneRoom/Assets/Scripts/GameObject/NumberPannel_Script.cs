using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberPannel_Script : MonoBehaviour
{
    public Int32 CurrentNumber { get; private set; } = 0;

    [System.Serializable]
    public class NumberSpriteDic : CustomDic.SerializableDictionary<Int32, Sprite>
    {
    }

    public NumberSpriteDic SpriteDic;

    public void IncNumber()
    {
        CurrentNumber = (CurrentNumber + 1) % 10;

        if (SpriteDic.ContainsKey(CurrentNumber))
        {
            var image = GetComponent<Image>();
            if (image != null)
            {
                image.sprite = SpriteDic[CurrentNumber];
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
