using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    CharacterData characterData;            // ����Data
    private float timer = 0f;               // �����ɶ���timer
    private bool isAttacking = false;       // �O�_�b����
    public BulletGenerator bulletGenerator; // �l�u�ͦ���
    private Animator animator;              // �ʵe
    private void Start()
    {
        characterData = CharacterManager.GetCharacterData();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        // �ƹ��������
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
        // �l�l����
        Debug.Log("�l�l����");
        GameObject attackArea = gameObject.transform.Find("AttackArea").gameObject;
        isAttacking = true;
        attackArea.SetActive(isAttacking);
    }
    private void FireProjectile()
    {
        // �o�g�l�u������
        Debug.Log("�}��");
        bulletGenerator.Fire();
    }
}
