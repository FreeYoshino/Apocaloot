using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    CharacterData characterData;            // 角色Data
    private float timer = 0f;               // 攻擊時間的timer
    private bool isAttacking = false;       // 是否在攻擊
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
                Debug.Log("遠程攻擊");
                break;
            case CharacterData.CharacterType.Shooter:
                Debug.Log("遠程攻擊");
                break;
            case CharacterData.CharacterType.Hammer:
                HammerAttack();
                break;
        }
    }

    private void HammerAttack()
    {
        // 槌子攻擊
        Debug.Log("槌子攻擊");
        GameObject attackArea = CharacterManager.GetCharacterObject().transform.Find("AttackArea").gameObject;
        isAttacking = true;
        attackArea.SetActive(isAttacking);
    }
}
