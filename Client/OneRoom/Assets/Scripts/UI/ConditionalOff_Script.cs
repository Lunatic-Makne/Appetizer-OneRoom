using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionalOff_Script : MonoBehaviour
{
    [SerializeField]
    private GameObject TargetObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public virtual bool CanOff()
    {
        return true;
    }

    public void TryOff()
    {
        if (TargetObject == null) {  return; }
        if (CanOff() == false) { return; }

        TargetObject.SetActive(false);
    }
}
