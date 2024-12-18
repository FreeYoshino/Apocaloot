using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEditor.Timeline;
using UnityEngine;

public class CrabController : MonoBehaviour
{
    float key = 1f;          //BOSS¬O§_Âà¦V
    float dis = 3.5f;
    float MoveSpeed = 2f;
    float AttackCD = 5f;
    float MoveCD;
    float time = 0f;
    float IdleCD;
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
        IdleCD = AttackCD - 1f;
        MoveCD = AttackCD + 0.0001f;
        transform.localScale = new Vector2(5f * key, 5f);
        rigidbody2D.velocity = new Vector2(MoveSpeed * key, rigidbody2D.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        now = transform.position;
        if (now.x > start.x + dis)
        {
            key = -1f;
        }
        else if (now.x < start.x - dis)
        {
            key = 1f;
        }
        if (rigidbody2D.velocity != new Vector2(0, 0))

        {
            transform.localScale = new Vector2(5f * key, 5f);
            rigidbody2D.velocity = new Vector2(MoveSpeed * key, rigidbody2D.velocity.y);
            animator.SetTrigger("CrabMove");
        }
        if (time > IdleCD)
        {
            animator.SetTrigger("CrabIdle");
            transform.localScale = new Vector2(5f * key, 5f);
            rigidbody2D.velocity = new Vector2(0, 0);
        }
        if (time > AttackCD)
        {
            animator.SetTrigger("CrabAttack");
        }
        if (time > MoveCD)
        {
            transform.localScale = new Vector2(5f * key, 5f);
            rigidbody2D.velocity = new Vector2(MoveSpeed * key, rigidbody2D.velocity.y);
            time = 0;

        }
        Debug.Log("time"+time);
        
    }

}
