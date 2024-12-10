using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    // ��ҼҦ�
    static CharacterManager instance;
    CharacterData myCharacterData;
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
        // �﨤���ư��]�w
        Debug.Log("Work");
        instance.myCharacterData = data;
    }
    public static void PrintCharacterData()
    {
        Debug.Log("CharacterName: " + instance.myCharacterData.characterName);
        Debug.Log("CharacterHp: " + instance.myCharacterData.characterHp);
        Debug.Log("CharacterPower: " + instance.myCharacterData.characterPower);
    }
    public static CharacterData GetCharacterData()
    {
        // �������Data
        if (instance.myCharacterData == null)
        {
            return null;
        }
        return instance.myCharacterData;
    }
    public static void ModifyMaxHp(float value)
    {
        instance.myCharacterData.characterMaxHp += value;
    }
    public static void ModifyHp(float value)
    {
        instance.myCharacterData.characterHp += value;
    }
    public static void ModifyPower(float value)
    {
        instance.myCharacterData.characterPower += value;
    }
    public static void UseItem(Item item, Inventory inventory)
    {
        // �ϥιD��
        if (item.itemHeld == 1)
        {
            inventory.itemList.Remove(item);
        }
        else
        {
            item.itemHeld -= 1;
        }
        ModifyMaxHp(item.itemHp);
        ModifyHp(item.itemHealing);
        ModifyPower(item.itemPower);
    }
}
