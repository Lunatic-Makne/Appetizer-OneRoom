using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpperBody_Script : MonoBehaviour
{
    [SerializeField]
    private Sprite OpenSprite;
    [SerializeField]
    private bool OpenStatus = false;

    [SerializeField]
    private GameObject PrevObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TryOpen()
    {
        if (OpenStatus) { return; }
        if (PrevObject == null) { return; }
        if (PrevObject.activeSelf) { return; }
        if (OpenSprite == null) { return; }

        OpenStatus = true;

        var image_comp = GetComponent<Image>();
        if (image_comp != null)
        {
            image_comp.sprite = OpenSprite;
        }
    }
}
