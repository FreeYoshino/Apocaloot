using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;

public class PinkStarController : MonoBehaviour
{
    float key = 1f;          //BOSS�O�_��V
    float dis = 4f;
    float AttackSpeed = 4f;
    float AttackAnimationSpeed = 0.3f;
    float AttackCD = 4f;
    float time = 0f;
    Vector2 start = new Vector2();
    Vector2 now = new Vector2();
    Rigidbody2D rigidbody2D;
    Animator animator;

    int maxHealth = 3;             // �̤j��q
    private int currentHealth;            // ��e��q
    private GameObject[] heartImages;     // �R�߹Ϥ��}�C
    private �p�Ǧ�qController healthController;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        // �����q�޲z��
        healthController = FindObjectOfType<�p�Ǧ�qController>();

        // ��l�ƷR�߹Ϥ�
        Transform canvasTransform = transform.Find("Canvas");
        if (canvasTransform != null)
        {
            Transform bloodTransform = canvasTransform.Find("Blood");
            if (bloodTransform != null)
            {
                heartImages = new GameObject[bloodTransform.childCount];
                for (int i = 0; i < bloodTransform.childCount; i++)
                {
                    heartImages[i] = bloodTransform.GetChild(i).gameObject;
                }
            }
        }
        //�H�W�B�z��q
        
        rigidbody2D = GetComponent<Rigidbody2D>();  
        start = transform.position;
        animator = GetComponent<Animator>();
    }

    public void TakeDamage()
    {
        // �I�s��q�޲z����s��q
        //animator.SetTrigger("PinkStarHurt");
        
        //if (currentHealth == 0) 
        //{
        //    animator.SetTrigger("PinkStarDie");  
        //}
        healthController.TakeDamage(currentHealth, heartImages, this.gameObject);
        currentHealth--; // ��s��e��q


    }
    // Update is called once per frame
    void Update()
    {
        // if(�l�u����)
        // {
        //     TakeDamage();
        // }
        //if (time > temp) 
        //{
        //    TakeDamage();
        //}

        time += Time.deltaTime;
        now = transform.position;
        if (now.x > start.x + dis)
        {  
            key = -1f;
            //animator.SetTrigger("PinkStarAttack2Idle");
        }
        else if (now.x < start.x - dis)
        {
            key = 1f;
            //animator.SetTrigger("PinkStarAttack2Idle");
        }
        Debug.Log(time);
        if (time > AttackCD)
        {
            if (key < 0f)
            {
                animator.SetTrigger("PinkStarAttack");
                
            }
            else
            {
                animator.SetTrigger("PinkStarAttackRight");
            }
            animator.speed = AttackAnimationSpeed;
            transform.localScale = new Vector2(5f * key, 5f);
            rigidbody2D.velocity = new Vector2(AttackSpeed * key, rigidbody2D.velocity.y);
            time = 0; 
        }
    }
}
