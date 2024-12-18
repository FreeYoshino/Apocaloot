using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;

public class PinkStarController : MonoBehaviour
{
    float key = 1f;          //BOSS¬O§_Âà¦V
    float dis = 4f;
    float AttackSpeed = 3f;
    float AttackAnimationSpeed = 0.3f;
    float AttackCD = 2f;
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
