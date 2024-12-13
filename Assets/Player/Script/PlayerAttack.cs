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
        // �ƹ��������
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
                Debug.Log("���{����");
                break;
            case CharacterData.CharacterType.Shooter:
                Debug.Log("���{����");
                break;
            case CharacterData.CharacterType.Hammer:
                Debug.Log("��ԧ���");
                break;
        }
        
    }
}
