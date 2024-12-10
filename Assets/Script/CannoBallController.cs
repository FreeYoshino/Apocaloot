using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannoBallController : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject canno, Player;
    GameObject right_border, left_border;
    float flyForce = 100f;
    float MaxSpeed = 6f;
    float direction;
    float time;
    float speed = 150f;
    Rigidbody2D rb;
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        canno = GameObject.Find("Canno");
        right_border = GameObject.Find("right_border");
        left_border = GameObject.Find("left_border");
        //Player = GameObject.Find("Player");
        direction = canno.transform.localScale.x;
        
        gameObject.transform.localScale = new Vector2(direction, 5f);
        rb = GetComponent<Rigidbody2D>();
        if (direction > 0)
        {
            rb.velocity = new Vector2(-MaxSpeed, 0);
        }
        else
            rb.velocity = new Vector2(MaxSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
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
}

