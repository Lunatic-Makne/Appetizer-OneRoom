using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class Inventory_Script : MonoBehaviour
{
    private static Inventory_Script instance;
    public static Inventory_Script Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (null == instance)
        {
            instance = this;
        }
    }

    private const int MAX_SLOT_COUNT = 16;
    private List<GameObject> slotList = new List<GameObject>();
    private void Start()
    {
        for (int i = 0; i < MAX_SLOT_COUNT; i++)
        {
            var slotNameString = string.Format("InvenSlot_{0}", i);
            var slotObject = GameObject.Find(slotNameString);
            if (slotObject != null)
            {
                slotList.Add(slotObject);
            }
        }
    }

    private bool needRefreshSlot = false;
    private Dictionary<string, GameObject> gameObjectDic = new Dictionary<string, GameObject>();
    public void AddObject(GameObject gameObject)
    {
        gameObjectDic.Add(gameObject.name, gameObject);
        needRefreshSlot = true;
    }

    private void Update()
    {
        TryRefreshSlot();
    }

    public void TryRefreshSlot()
    {
        if (needRefreshSlot == false) { return; }

        slotList.ForEach(delegate (GameObject obj)
        {
            var slotScript = obj.GetComponent<InvenSlot_Script>();
            slotScript.ResetSlot();
        });

        int index = 0;
        foreach (var obj in gameObjectDic.Values)
        {
            var slotScript = slotList[index].GetComponent<InvenSlot_Script>();
            slotScript.AddItem(obj);
            ++index;
        }
    }
}
