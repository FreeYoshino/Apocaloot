using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    CharacterData characterData;            // 角色Data
    private float timer = 0f;               // 攻擊時間的timer
    private bool isAttacking = false;       // 是否在攻擊
    public BulletGenerator bulletGenerator; // 子彈生成器
    private Animator animator;              // 動畫
    private void Start()
    {
        characterData = CharacterManager.GetCharacterData();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        // 滑鼠左鍵攻擊
        if (Input.GetMouseButtonDown(0) && !isAttacking)
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
                if (characterData.characterType == CharacterData.CharacterType.Hammer) gameObject.transform.Find("AttackArea").gameObject.SetActive(isAttacking);  
            }
        }

    }
    private void Attack()
    {
        animator.SetTrigger("Attack");
        switch (characterData.characterType)
        {
            case CharacterData.CharacterType.Archer:
                FireProjectile();
                break;
            case CharacterData.CharacterType.Shooter:
                FireProjectile();
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
        GameObject attackArea = gameObject.transform.Find("AttackArea").gameObject;
        isAttacking = true;
        attackArea.SetActive(isAttacking);
    }
    private void FireProjectile()
    {
        // 發射子彈類攻擊
        Debug.Log("開火");
        bulletGenerator.Fire();
    }
}
