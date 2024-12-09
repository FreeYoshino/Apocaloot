using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/New Item")]
public class Item : ScriptableObject
{
    // �~��ScriptableObject�� �x�sItem����T
    public string itemName;
    public Sprite itemImage;
    public int itemHeld;
    [TextArea]
    public string itemInfo;

    public bool use;            // �ϧ_�i�H�ϥ�
    public float itemHp;        // ��q�ĪG
    public float itemPower;      // �����O�ĪG

}
