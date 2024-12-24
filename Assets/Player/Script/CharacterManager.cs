using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    // 單例模式
    public static CharacterManager instance;
    public CharacterData myCharacterData;
    public HealthBar myHealthBar;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(instance);
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public static void InitializeCharacterData(CharacterData data)
    {
        if (data == null)
        {
            Debug.Log("CharacterData is null");
            return;
        }
        // 對角色資料做設定
        Debug.Log("Selected Character: " + data.characterName);
        instance.myCharacterData = data;
    }
    public void OnGameSceneLoad()
    {
        // 遊戲場景載入後 要更新血調顯示的內容
        myHealthBar = GameObject.Find("PlayerHealthBar").GetComponent<HealthBar>();
        myHealthBar.SetMaxHealth(myCharacterData.characterMaxHp, myCharacterData.characterHp);
    }
    public static void PrintCharacterData()
    {
        Debug.Log("CharacterName: " + instance.myCharacterData.characterName);
        Debug.Log("CharacterHp: " + instance.myCharacterData.characterHp);
        Debug.Log("CharacterPower: " + instance.myCharacterData.characterPower);
    }
    public static CharacterData GetCharacterData()
    {
        // 獲取角色Data
        if (instance.myCharacterData == null)
        {
            return null;
        }
        return instance.myCharacterData;
    }
    public static GameObject GetCharacterObject()
    {
        if (instance.myCharacterData == null)
        {
            return null;
        }
        return GameObject.Find(instance.myCharacterData.characterName); 
    }
    public void IncreaseMaxHp(float value)
    {
        instance.myCharacterData.characterMaxHp += value;
        instance.myHealthBar.SetMaxHealth(myCharacterData.characterMaxHp, myCharacterData.characterHp);
    }
    public void IncreaseHp(float value)
    {
        instance.myCharacterData.characterHp += value;
        instance.myHealthBar.SetHealth(myCharacterData.characterHp);
    }
    public void DecreaseHp(float value)
    {
        instance.myCharacterData.characterHp -= value;
        instance.myHealthBar.SetHealth(myCharacterData.characterHp);
        if (instance.myCharacterData.characterHp <= 0)
        {
            CharacterManager.GetCharacterObject().GetComponent<CharacterAudioController>().PlayDeadSound();
            GameManager.instance.GameOver(false);
        }
    }
    public void IncreasePower(float value)
    {
        instance.myCharacterData.characterPower += value;
    }
    public void UseItem(Item item, Inventory inventory)
    {
        // 使用道具
        InventoryManager.instance.consumeItem(item);
        IncreaseMaxHp(item.itemHp);
        IncreaseHp(item.itemHealing);
        IncreasePower(item.itemPower);
    }
}
