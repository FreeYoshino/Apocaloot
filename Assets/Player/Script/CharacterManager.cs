using System.Collections;
using System.Collections.Generic;
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
        instance.myCharacterData = data;
    }
}
