using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;
using TMPro;
public class InventoryManager : MonoBehaviour
{
    // 單例模式
    static InventoryManager instance;

    public Inventory myBag;             // 對應到的背包
    public Item[] allItems;             // 所有道具的表
    public Item itemSelected;           // 被選中的道具
    public GameObject slotGrid;         // UI的Grid
    public GameObject MessagePanel;     // MessagePanel
    public Slot slotPrefab;             // Slot
    public TMP_Text itemInformation;    // Text

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(instance);
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void OnEnable()
    {
        InitializeInventory();
        // RefreshItem();
        // instance.itemInformation.text = "";
    }

    public void OnGameSceneLoaded()
    {
        // 切換場景時操作
        GameObject bag = GameObject.Find("Bag");
        bag.SetActive(true);
        slotGrid = GameObject.Find("Canvas/Bag/Grid");
        itemInformation = GameObject.Find("Canvas/Bag/ItemDescription").GetComponent<TMP_Text>();
        MessagePanel = GameObject.Find("Canvas/MessagePanel");
        bag.SetActive(false);
        RefreshItem();
    }

    public void InitializeInventory()
    {
        // 初始化背包、道具數量
        myBag.itemList.Clear();
        for (int i = 0; i < allItems.Length; i++)
        {
            allItems[i].itemHeld = 1;
        }
    }   
    public void OnUseButtonClicked()
    {
        // 點擊使用按鈕的事件
        MessagePanel.SetActive(true);       // 顯示MessagePanel
        TMP_Text  message = MessagePanel.transform.Find("Message").GetComponent<TMP_Text>();
        if (itemSelected == null || !myBag.itemList.Contains(itemSelected))
        {
            message.text = "Please Select Item.";
        }
        else
        {
            if (itemSelected.use == true)
            {
                CharacterManager.instance.UseItem(itemSelected, myBag);
                message.text = "Use " + itemSelected.itemName + " item.";
                RefreshItem();
            }
            else
            {
                message.text = "This item can't used.";
            }
        }
    }
    public static void UpdateItemInfo(Item item)
    {
        // 更新道具選取情形
        instance.itemInformation.text = item.itemInfo;    
        instance.itemSelected = item;
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
