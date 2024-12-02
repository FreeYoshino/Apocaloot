using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOnWorld : MonoBehaviour
{
    public Item thisItem;                       // Item ��
    public Inventory playerInventory;           // Inventory ��
    private bool isPlayerInRange = false;       // �˴����a�O�_�b���~�I���d��

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ����i�J�I���d��
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true; 
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        // �������}�I���d��
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
        // ���a�b�d�򤺥B���U�椬��~�|�B�����~
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.F))
        {
            AddNewItem();
            Destroy(gameObject);
        }
    }
}
