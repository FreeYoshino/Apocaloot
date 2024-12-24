using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;

public class PinkStarController : MonoBehaviour
{
    float key = 1f;          //BOSS是否轉向
    float dis = 3f;
    float AttackSpeed = 4f;
    float AttackAnimationSpeed = 0.3f;
    float AttackCD = 4f;
    float time = 0f;
    Vector2 start = new Vector2();
    Vector2 now = new Vector2();
    Rigidbody2D rigidbody2D;
    Animator animator;


    // Start is called before the first frame update
    void Start()
    {

        
        rigidbody2D = GetComponent<Rigidbody2D>();  
        start = transform.position;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {


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
        //Debug.Log(time);
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
    private void OnCollisionEnter2D(Collision2D collision)
    {

            // Debug.Log("發生碰撞");
            if (collision != null && collision.gameObject.CompareTag("Player"))
            {
                collision.gameObject.GetComponent<PlayerHurt>().Hurt(20f);
                animator.Play("PinkStarHurt");
                // Debug.Log("攻擊敵人"); 
            }
    }
}
