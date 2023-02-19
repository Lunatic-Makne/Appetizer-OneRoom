using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PasswordPannel_Script : MonoBehaviour
{
    [SerializeField]
    public Int32 Password = 0;

    public enum ENumberSlotType
    {
        NUMBER_SLOT_1,
        NUMBER_SLOT_2,
        NUMBER_SLOT_3,
        NUMBER_SLOT_4,
    }

    [System.Serializable]
    public class NumberPannelDic : CustomDic.SerializableDictionary<ENumberSlotType, GameObject>
    {
    }

    public NumberPannelDic NumberDic;

    public bool IsCorrect()
    {
        Int32 total_number = 0;
        foreach (var pair in NumberDic)
        {
            total_number *= 10;

            var game_object = pair.Value;
            if (game_object.GetComponent<NumberPannel_Script>() != null)
            {
                total_number += game_object.GetComponent<NumberPannel_Script>().CurrentNumber;
            }
        }

        return Password == total_number;
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
