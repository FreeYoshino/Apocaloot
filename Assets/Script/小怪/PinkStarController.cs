using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;

public class PinkStarController : MonoBehaviour
{
    float key = 1f;          //BOSS是否轉向
    float dis = 4f;
    float AttackSpeed = 4f;
    float AttackAnimationSpeed = 0.3f;
    float AttackCD = 4f;
    float time = 0f;
    Vector2 start = new Vector2();
    Vector2 now = new Vector2();
    Rigidbody2D rigidbody2D;
    Animator animator;

    int maxHealth = 3;             // 最大血量
    private int currentHealth;            // 當前血量
    private GameObject[] heartImages;     // 愛心圖片陣列
    private 小怪血量Controller healthController;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        // 獲取血量管理器
        healthController = FindObjectOfType<小怪血量Controller>();

        // 初始化愛心圖片
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
        //以上處理血量
        
        rigidbody2D = GetComponent<Rigidbody2D>();  
        start = transform.position;
        animator = GetComponent<Animator>();
    }

    public void TakeDamage()
    {
        // 呼叫血量管理器更新血量
        //animator.SetTrigger("PinkStarHurt");
        
        //if (currentHealth == 0) 
        //{
        //    animator.SetTrigger("PinkStarDie");  
        //}
        healthController.TakeDamage(currentHealth, heartImages, this.gameObject);
        currentHealth--; // 更新當前血量


    }
    // Update is called once per frame
    void Update()
    {
        // if(子彈打到)
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
