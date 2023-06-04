using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Elevator_Display_Pannel_Script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [System.Serializable]
    public class NumberSpriteDic : CustomDic.SerializableDictionary<Int32, Sprite>
    {
    }

    public NumberSpriteDic SpriteDic;

    public void OnFloorButtonClicked(Int32 floorNumber)
    {
        if (SpriteDic != null)
        {
            if (SpriteDic.ContainsKey(floorNumber)) 
            {
                var image = GetComponent<Image>();
                if (image != null)
                {
                    image.sprite = SpriteDic[floorNumber];
                }
            }
        }
    }
}
