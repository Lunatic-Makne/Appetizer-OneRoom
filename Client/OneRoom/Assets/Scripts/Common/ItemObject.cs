using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : DerivedClickObject
{
    private bool inInventory = false;
    protected void ToInventory()
    {
        if (inInventory) { return; }

        inInventory = true;
        disabled = true;

        Inventory_Script.Instance.AddObject(this.gameObject);
    }

    public override void OnClicked()
    {
        base.OnClicked();
        if (false == inInventory)
        {
            ToInventory();
        }
    }

    protected override void CheckDisableStatus()
    {
        if (false == inInventory)
        {
            base.CheckDisableStatus();
        }
    }
}
