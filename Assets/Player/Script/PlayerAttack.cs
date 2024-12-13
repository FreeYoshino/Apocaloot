using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    CharacterData characterData;            // ����Data
    private float timer = 0f;               // �����ɶ���timer
    private bool isAttacking = false;       // �O�_�b����
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
        if (isAttacking)
        {
            timer += Time.deltaTime;
            if (timer >= characterData.characterTimeToAttack)
            {
                timer = 0f;
                isAttacking = false;
                if (characterData.characterType == CharacterData.CharacterType.Hammer) CharacterManager.GetCharacterObject().transform.Find("AttackArea").gameObject.SetActive(isAttacking);  
            }
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
                HammerAttack();
                break;
        }
    }

    private void HammerAttack()
    {
        // �l�l����
        Debug.Log("�l�l����");
        GameObject attackArea = CharacterManager.GetCharacterObject().transform.Find("AttackArea").gameObject;
        isAttacking = true;
        attackArea.SetActive(isAttacking);
    }
}
