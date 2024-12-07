using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class InventoryManager : MonoBehaviour
{
    // ³æ¨Ò¼Ò¦¡
    static InventoryManager instance;

    public Inventory myBag;
    public GameObject slotGrid;
    public Slot slotPrefab;
    public TMP_Text itemInformation;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(instance);
        }
        instance = this;
    }

    private void OnEnable()
    {
        RefreshItem();
        instance.itemInformation.text = "";
    }
    
    public static void UpdateItemInfo(string itmeDescription)
    {
        instance.itemInformation.text = itmeDescription;    
    }
    public static void CreateNewItem(Item item)
    {
        Slot newItem = Instantiate(instance.slotPrefab, instance.slotGrid.transform.position, Quaternion.identity);
        newItem.gameObject.transform.SetParent(instance.slotGrid.transform);
        newItem.slotItem = item;
        newItem.slotImage.sprite = item.itemImage;
        newItem.slotNum.text = item.itemHeld.ToString();
    }
    public static void RefreshItem()
    {
        for (int i = 0; i < instance.slotGrid.transform.childCount; i++)
        {
            if (instance.slotGrid.transform.childCount == 0)
                break;
            Destroy(instance.slotGrid.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < instance.myBag.itemList.Count; i++)
        {
            CreateNewItem(instance.myBag.itemList[i]);
        }
    }
}
