using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    CharacterData characterData;            // 角色Data
    CharacterController2D characterController;// 角色控制腳本
    private float timer = 0f;               // 攻擊時間的timer
    private bool isAttacking = false;       // 是否在攻擊
    public BulletGenerator bulletGenerator; // 子彈生成器
    private Animator animator;              // 動畫
    private Vector3 mousePosition;          // 滑鼠點擊的位置 
    private void Start()
    {
        characterData = CharacterManager.GetCharacterData();
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController2D>();
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
        isAttacking = true;
        animator.SetTrigger("Attack");
        if (characterData.characterType == CharacterData.CharacterType.Hammer)
        {
            // 槌子攻擊
            HammerAttack();
        }
        else
        {
            // 遠程攻擊
            FireProjectile();
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
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);    // 將點擊的位置轉為世界座標
        mousePosition.z = 0f;
        Vector3 shootDirection = (mousePosition - gameObject.transform.position).normalized;    // 計算射擊方向
        if (characterController.m_FacingRight != (shootDirection.x > 0)) characterController.Flip();    // 子彈發射方向與角色面朝方向不同Flip()
        bulletGenerator.Fire(shootDirection);
    }
}
