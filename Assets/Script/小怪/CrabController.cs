using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEditor.Timeline;
using UnityEngine;

public class CrabController : MonoBehaviour
{
    float key = 1f;          //BOSS是否轉向
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
    public BoxCollider2D attackCollider;

    
    // Start is called before the first frame update
    void Start()
    {
        attackCollider = GetComponent<BoxCollider2D>();
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
            StartAttack();
            animator.SetTrigger("CrabAttack");
        }
        if (time > MoveCD)
        {
            EndAttack();
            transform.localScale = new Vector2(5f * key, 5f);
            rigidbody2D.velocity = new Vector2(MoveSpeed * key, rigidbody2D.velocity.y);
            time = 0;

        }
        //Debug.Log("time"+time);
        
    }
    void StartAttack()
    {
        // 設定攻擊時的碰撞大小
        attackCollider.size = new Vector2(0.7f, 0.1f); // 增加碰撞寬度
        attackCollider.offset = new Vector2(0f, -0.05f); // 偏移到手的位置
    }

    void EndAttack()
    {
        // 回復到預設大小
        attackCollider.size = new Vector2(0.4f, 0.1f);
        attackCollider.offset = new Vector2(0.0f, 0f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log("發生碰撞");
        if (collision != null && collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHurt>().Hurt(20f);
            Debug.Log("攻擊敵人");
        }
    }
}
