using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossController : MonoBehaviour
{
    public GameObject SwordPrefab;
    float WalkForce = 40f;
    float JumpForce = 100f;
    float MaxSpeed = 1f;
    float key = 1f;
    float run = 5f;
    float dis = 5f;
    float CD = 2f;
    float AnimatorSpeed = 3f;
    Vector2 NowPosition;
    Vector2 start = new Vector2();
    //public Transform PlayerTransform;

    Animator animator;

    Rigidbody2D rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        NowPosition = transform.position;
        start = transform.position;

    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x > NowPosition.x + dis)
        {
            key = -1f;
        }
        else if (transform.position.x < NowPosition.x - dis)
        {
            key = 1f;
        }
        if (rigidbody2D.velocity == new Vector2(0, 0))
        {
            animator.enabled = true;
        }
        CD += Time.deltaTime;
        if (CD > 5)
        {
            transform.localScale = new Vector2(5f * key, 5f);
            CD = 0;
            animator.SetTrigger("BossThrowAttack");
            animator.speed = AnimatorSpeed;
            GameObject spin = Instantiate(SwordPrefab);
            spin.transform.position = gameObject.transform.position;
            animator.speed = 1f;

        }





        //transform.localScale = new Vector2(7f * key, 7f);
        //rigidbody2D.velocity = new Vector2(run * key, rigidbody2D.velocity.y);


        //float PlayerDistance = Vector2.Distance(transform.position, PlayerTransform.position);
        //if (PlayerDistance < 10f)
        //{
        //    CD += Time.deltaTime;
        //    if (transform.position.x > PlayerTransform.position.x)
        //    {
        //        key = -1f;
        //    }
        //    else if (transform.position.x < PlayerTransform.position.x)
        //    {
        //        key = 1f;
        //    }
        //    if (CD > 2)
        //    {
        //        transform.localScale = new Vector2(7f * key, 7f);
        //        animator.SetTrigger("throw");
        //        animator.speed = 0.5f;
        //        CD = 0;
        //        GameObject spin = Instantiate(SwordPrefab);
        //        spin.transform.position = gameObject.transform.position;
        //    }
        //transform.localScale = new Vector2(7f * key, 7f);
        //rigidbody2D.velocity = new Vector2(run * key, rigidbody2D.velocity.y);


        //}
        //if (PlayerDistance < 5f)
        //{
        //    if (transform.position.x > PlayerTransform.position.x)
        //    {
        //        key = -1f;
        //    }
        //    else if (transform.position.x < PlayerTransform.position.x)
        //    {
        //        key = 1f;
        //    }
        //    transform.localScale = new Vector2(7f * key, 7f);
        //    rigidbody2D.velocity = new Vector2(run * key, rigidbody2D.velocity.y);
        //    animator.SetTrigger("attack3");
        //    animator.speed = 0.5f;
        //}
        //else
        //{
        //    if (transform.position.x > start.x + dis)
        //    {
        //        key = -1f;
        //    }
        //    else if (transform.position.x < start.x - dis)
        //    {
        //        key = 1f;
        //    }
        //    transform.localScale = new Vector2(7f * key, 7f);
        //    rigidbody2D.velocity = new Vector2(run * key, rigidbody2D.velocity.y);
        //}




        //    float key = 0f;
        //    if (Input.GetKeyDown(KeyCode.G))
        //    {
        //        animator.SetTrigger("attack3");
        //        animator.speed = 0.87f;
        //    }

        //    if (Input.GetKeyDown(KeyCode.F))
        //    {
        //        animator.SetTrigger("throw");
        //        animator.speed = 0.87f;
        //        GameObject spin = Instantiate(SwordPrefab);
        //        spin.transform.position = gameObject.transform.position;
        //    }

        //    if (Input.GetKey(KeyCode.LeftArrow))
        //    {
        //        key = -1f;
        //    }
        //    if (Input.GetKey(KeyCode.RightArrow))
        //    {
        //        key = 1f;
        //    }
        //    if (rigidbody2D.velocity.y == 0 && Input.GetKeyDown(KeyCode.Space))
        //    {
        //        animator.SetTrigger("jump_sword");
        //        animator.speed = 0.87f;
        //        rigidbody2D.AddForce(transform.up * JumpForce);
        //    }
        //    float speedx = Mathf.Abs(rigidbody2D.velocity.x);
        //    if (speedx < MaxSpeed)
        //    {
        //        rigidbody2D.AddForce(transform.right * key * WalkForce);
        //    }
        //    if (key != 0)
        //    {
        //        transform.localScale = new Vector2(7f * key, 7f);

        //    }
        //    if (rigidbody2D.velocity.y == 0)
        //    {
        //        animator.speed = speedx / 2.0f;
        //    }
    }
}
