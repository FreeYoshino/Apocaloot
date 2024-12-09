using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/New Item")]
public class Item : ScriptableObject
{
    // 繼承ScriptableObject類 儲存Item的資訊
    public string itemName;
    public Sprite itemImage;
    public int itemHeld;
    [TextArea]
    public string itemInfo;

    public bool use;            // 使否可以使用
    public float itemHp;        // 血量效果
    public float itemPower;      // 攻擊力效果

}
