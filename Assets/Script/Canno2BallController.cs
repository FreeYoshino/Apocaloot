using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannoBall2Controller : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject right_border, left_border;
    float flyForce = 100f;
    float MaxSpeed = 6f;
    float time;
    float speed = 150f;
    float bulletSpeed = 5f; // 子彈速度
    Rigidbody2D rb;
    Animator animator;
    GameObject player;
    Vector2 direction;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        animator = GetComponent<Animator>();
        right_border = GameObject.Find("right_border");
        left_border = GameObject.Find("left_border");
        rb = GetComponent<Rigidbody2D>();
        direction = (player.transform.position - transform.position).normalized;
        

    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log("方向: " + direction);
        rb.velocity = direction * bulletSpeed;
        Debug.Log("速度: " + rb.velocity);
        if (gameObject.transform.position.x > right_border.transform.position.x)
        {
            //animator.SetTrigger("CannoBall");
            Destroy(gameObject);
        }
        if (gameObject.transform.position.x < left_border.transform.position.x)
        {
            //animator.SetTrigger("CannoBall");
            Destroy(gameObject);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log("發生碰撞");
        if (collision != null && collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHurt>().Hurt(20f);
            Debug.Log("攻擊敵人");
            
        }
        Destroy(gameObject);
    }
    
}

