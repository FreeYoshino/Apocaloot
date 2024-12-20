using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    CharacterData characterData;            // ����Data
    CharacterController2D characterController;// ���ⱱ��}��
    private float timer = 0f;               // �����ɶ���timer
    private bool isAttacking = false;       // �O�_�b����
    public BulletGenerator bulletGenerator; // �l�u�ͦ���
    private Animator animator;              // �ʵe
    private Vector3 mousePosition;          // �ƹ��I������m 
    private void Start()
    {
        characterData = CharacterManager.GetCharacterData();
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController2D>();
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
        isAttacking = true;
        animator.SetTrigger("Attack");
        if (characterData.characterType == CharacterData.CharacterType.Hammer)
        {
            // �l�l����
            HammerAttack();
        }
        else
        {
            // ���{����
            FireProjectile();
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
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);    // �N�I������m�ର�@�ɮy��
        mousePosition.z = 0f;
        Vector3 shootDirection = (mousePosition - gameObject.transform.position).normalized;    // �p��g����V
        if (characterController.m_FacingRight != (shootDirection.x > 0)) characterController.Flip();    // �l�u�o�g��V�P���⭱�¤�V���PFlip()
        bulletGenerator.Fire(shootDirection);
    }
}
