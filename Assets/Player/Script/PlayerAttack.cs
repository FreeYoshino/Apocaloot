using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    CharacterData characterData;
    private void Start()
    {
        characterData = CharacterManager.GetCharacterData();
    }
    private void Update()
    {
        // 滑鼠左鍵攻擊
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }
    private void Attack()
    {
        switch (characterData.characterType)
        {
            case CharacterData.CharacterType.Archer:
                Debug.Log("遠程攻擊");
                break;
            case CharacterData.CharacterType.Shooter:
                Debug.Log("遠程攻擊");
                break;
            case CharacterData.CharacterType.Hammer:
                Debug.Log("近戰攻擊");
                break;
        }
        
    }
}
