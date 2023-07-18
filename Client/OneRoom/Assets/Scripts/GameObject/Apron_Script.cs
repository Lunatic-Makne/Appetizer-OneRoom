using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apron_Script : ConditionalOff_Script
{
    [SerializeField]
    private GameObject CheckObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override bool CanOff()
    {
        if (CheckObject != null)
        {
            return CheckObject.activeSelf == true;
        }

        return false;
    }
}
