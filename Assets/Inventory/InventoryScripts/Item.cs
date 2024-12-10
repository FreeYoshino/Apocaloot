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

    public bool use;                // 使否可以使用
    public float itemHealing;       // 回血效果
    public float itemHp;            // 增加血量上限效果
    public float itemPower;         // 攻擊力效果

}
