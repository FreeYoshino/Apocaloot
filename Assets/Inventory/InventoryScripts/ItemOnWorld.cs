using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOnWorld : MonoBehaviour
{
    public Item thisItem;                       // Item 類
    public Inventory playerInventory;           // Inventory 類
    private bool isPlayerInRange = false;       // 檢測玩家是否在物品碰撞範圍內

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 角色進入碰撞範圍
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true; 
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        // 角色離開碰撞範圍
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }
    public void AddNewItem()
    {
        if (!playerInventory.itemList.Contains(thisItem))
        {
            playerInventory.itemList.Add(thisItem);
        }
        else
        {
            thisItem.itemHeld += 1;
        }
    }
    private void Update()
    {
        // 玩家在範圍內且按下交互鍵才會拾取物品
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.F))
        {
            AddNewItem();
            Destroy(gameObject);
        }
    }
}
