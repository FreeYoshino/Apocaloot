using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.UI.Image;

public class BossController : MonoBehaviour
{
    public GameObject SwordPrefab;
    //public GameObject PlayerBullet;
 
    float JumpForce = 18f;    //BOSS跳的力道
    float JumpX = 0.1f;
    float key = 1f;          //BOSS是否轉向
    float run = 5f;         //move的速度
    float dis = 15f;        //Boss移動距離範圍
    float CD = 0f;          //總CD
    float ThrowSpeed = 3f; //丟刀動畫速度
    float ThrowCD = 5f;    //丟刀CD
    float IdleCD;          //閒置CD
    float MoveCD;         //移動CD
    float Jumptime = 20f; //跳的CD
    float rayLength = 2.4f; //偵測高度
    float raydis = 2f;   //偵測是否跳的距離
    float direction;  // Boss 方向
    float JumpCD = 0f; // 跳的CD是否還在
    float time=0f;
    Vector2 NowPosition;
    Vector2 start = new Vector2();
    //public Transform PlayerTransform;
    //取的地形的橋的圖層
    public LayerMask bridgeLayer; 
    Animator animator;

    Rigidbody2D rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        bridgeLayer = LayerMask.GetMask("JumpablePlatform");
        IdleCD = ThrowCD - 1.5f;
        MoveCD = ThrowCD + 1.5f;
        Application.targetFrameRate = 60;
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.enabled = true;
        animator.speed = 1f;
        NowPosition = transform.position;
        start = transform.position;
        transform.localScale = new Vector2(9f * key, 9f);
        rigidbody2D.velocity = new Vector2(run * key, rigidbody2D.velocity.y);

    }

    // Update is called once per frame
    void Update()
    {
        direction = transform.localScale.x > 0 ? 1 : -1;
        RaycastHit2D hit = Physics2D.Raycast(transform.position+new Vector3(raydis*direction,0,0), Vector2.up, rayLength, bridgeLayer);

        if (JumpCD == 1) 
        {
            time += Time.deltaTime;
            if (time >= Jumptime)
            {
                time = 0;
                JumpCD = 0f;
            }
        }
        //是否要跳
        if (JumpCD == 0f)
        {
            if (hit.collider != null)
            {
                CD = 0;
                JumpCD = 1f;
                //Debug.Log("Detected bridge: " + hit.collider.gameObject.name);
                rigidbody2D.velocity = new Vector2(JumpX,JumpForce); // 設置垂直速度
                animator.SetTrigger("Bossjump");
                

            }
        }
        //設定角色是否轉向
        if (transform.position.x > NowPosition.x + dis)
        {
            key = -1f;
        }
        else if (transform.position.x < NowPosition.x - dis)
        {
            key = 1f;
        }
        if (rigidbody2D.velocity != new Vector2(0, 0))

        {
            transform.localScale = new Vector2(9f * key, 9f);
            rigidbody2D.velocity = new Vector2(run * key, rigidbody2D.velocity.y);
            animator.SetTrigger("BossMove");
        }
        else
        {

            if(CD > MoveCD)
            {
                transform.localScale = new Vector2(9f * key, 9f);
                rigidbody2D.velocity = new Vector2(run * key, rigidbody2D.velocity.y);
                ThrowCD = 5f;
                CD = 0;
            }
        }
        



        CD += Time.deltaTime;
        if (CD > IdleCD)
        {
            animator.SetTrigger("BossMove2Idle");
            rigidbody2D.velocity = new Vector2(0, 0);
        }
        if (CD > ThrowCD)
        {
            transform.localScale = new Vector2(9f * key, 9f);
            transform.localScale = new Vector2(9f * key, 9f);
            CD = 0;
            transform.localScale = new Vector2(9f * key, 9f);
            rigidbody2D.velocity = new Vector2(run * key, rigidbody2D.velocity.y);
            animator.SetTrigger("BossMove");
        }
        else
        {
            //移動設定
            if (CD > MoveCD)
            {
                transform.localScale = new Vector2(9f * key, 9f);
                rigidbody2D.velocity = new Vector2(run * key, rigidbody2D.velocity.y);
                ThrowCD = 5f;
                CD = 0;
            }
        }
        //丟刀設定
        CD += Time.deltaTime;
        if (CD > IdleCD)
        {
            animator.SetTrigger("BossMove2Idle");
            rigidbody2D.velocity = new Vector2(0, 0);
        }
        if (CD > ThrowCD)
        {
            transform.localScale = new Vector2(9f * key, 9f);
            animator.SetTrigger("BossThrowAttack");
            animator.speed = ThrowSpeed;
            GameObject spin = Instantiate(SwordPrefab);
            spin.transform.position = gameObject.transform.position;
            animator.speed = 1f;
            ThrowCD = float.PositiveInfinity;

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
    void OnDrawGizmos()
    {
        
    //    Debug.Log("rwge");
       Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.up * rayLength);
    }

}
