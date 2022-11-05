using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InvenSlot_Script : MonoBehaviour
{
    private bool hasItem = false;
    private GameObject itemObject = null;
    private Sprite itemImage = null;

    private void Update()
    {
        var spriteRender = GetComponent<SpriteRenderer>();
        if (spriteRender != null)
        {
            if (hasItem == false)
            {
                spriteRender.enabled = false;
            }
            else
            {
                spriteRender.enabled = true;
                spriteRender.sprite = itemImage;
            }
        }
    }

    public void ResetSlot()
    {
        hasItem = false;
        itemObject = null;
    }

    public void AddItem(GameObject item)
    {
        hasItem = true;
        itemObject = item;
        itemImage = item.GetComponent<SpriteRenderer>()?.sprite;
    }
}
