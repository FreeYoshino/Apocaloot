using JetBrains.Annotations;
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
    float knifeCD = 1.5f;           //BOSS揮刀CD
    float JumpForce = 11f;    //BOSS跳的力道
    float JumpX = 0.1f;
    float key = 1f;          //BOSS是否轉向
    float run = 3f;         //move的速度
    float dis = 15f;        //Boss移動距離範圍
    float CD = 0f;          //總CD
    float ThrowSpeed = 3f; //丟刀動畫速度
    float ThrowCD = 5f;    //丟刀CD
    float IdleCD;          //閒置CD
    float MoveCD;         //移動CD
    float Jumptime = 1f; //跳的CD
    float rayLength = 2.4f; //偵測高度
    float groundlength = 0.8f; //偵測是否轉向
    float BossCollider = 3f; //偵測是否轉向，稍大於Bosscollider
    float raydis = 5f;   //偵測是否跳的距離
    float direction;  // Boss 方向
    float JumpCD = 0f; // 跳的CD是否還在
    float time=0f;
    float JumpSpeed = 0.5f; //跳躍的動畫時間
    bool isGrounded; // 是否在地面上
    float checkRadius = 0.3f; // 檢測是否在地上的半徑
    float gravity = 0f;  //重力
    [SerializeField]float palyerCD = 5f;
    Vector3 ground = new Vector3(0, -1f,0);
    Vector2 NowPosition;
    Vector2 start = new Vector2();
    GameObject PlayerTransform;
    //取的地形的橋的圖層
    public LayerMask bridgeLayer;
    GameObject player;
    Animator animator;

    Rigidbody2D rigidbody2D;
    public GameObject AttackArea;
    private float attackCD = 2f;
    public bool canAttack = true;
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
        PlayerTransform = CharacterManager.GetCharacterObject();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(rigidbody2D.velocity);
        direction = transform.localScale.x > 0 ? 1 : -1;
        RaycastHit2D hit = Physics2D.Raycast(transform.position+new Vector3(raydis*direction,0,0), Vector2.up, rayLength, bridgeLayer);
        RaycastHit2D turn = Physics2D.Raycast(transform.position + new Vector3(BossCollider * direction,0,0), Vector3.down, groundlength);

        isGrounded = Physics2D.OverlapCircle(transform.position + ground, checkRadius, bridgeLayer);
        Collider2D hitCollider = Physics2D.OverlapCircle(transform.position + ground, checkRadius, bridgeLayer);
        if (isGrounded)
        {
            //Debug.Log("isgrounded");
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
                if (hit.collider != null && !hit.collider.CompareTag("Player"))
                {
                    CD = 0;
                    JumpCD = 1f;
                    //Debug.Log("Detected bridge: " + hit.collider.gameObject.name);
                    rigidbody2D.velocity = new Vector2(JumpX, JumpForce); // 設置垂直速度
                    animator.SetTrigger("Bossjump");
                    animator.speed = JumpSpeed;


                }
            }
            //設定角色是否轉向
            // if (transform.position.x > NowPosition.x + dis)

            //else if (transform.position.x < NowPosition.x - dis)
            //{
            //key = 1f;
            //}
            if (transform.position.x > 19 || transform.position.x < -15)
            {
                key *= -1;
            }
            else if (turn.collider != null)
            {
                if (!turn.collider.CompareTag("Player"))
                {
                    key *= -1; // 執行反轉邏輯
                }
            }
            if (rigidbody2D.velocity != new Vector2(0, gravity))

            {
                transform.localScale = new Vector2(9f * key, 9f);
                rigidbody2D.velocity = new Vector2(run * key, rigidbody2D.velocity.y);
                animator.SetTrigger("BossMove");
            }



            if (CD > MoveCD)
            {
                transform.localScale = new Vector2(9f * key, 9f);
                rigidbody2D.velocity = new Vector2(run * key, rigidbody2D.velocity.y);
                ThrowCD = 5f;
                CD = 0;
            }

            //丟刀設定
            CD += Time.deltaTime;
            if (CD > IdleCD)
            {
                animator.SetTrigger("BossMove2Idle");
                rigidbody2D.velocity = new Vector2(0, gravity);
            }
            if (CD > ThrowCD)
            {
                if (hitCollider != null && hitCollider.CompareTag("Player"))
                {
                    transform.localScale = new Vector2(9f * key, 9f);
                    animator.SetTrigger("BossThrowAttack");
                    animator.speed = ThrowSpeed;
                    GameObject spin = Instantiate(SwordPrefab);
                    spin.transform.position = gameObject.transform.position;
                    animator.speed = 1f;
                    ThrowCD = float.PositiveInfinity;
                }
            }
        }
        float PlayerDistance = Vector2.Distance(transform.position, PlayerTransform.transform.position);
        Vector2 PlayerPosition = PlayerTransform.transform.position;
        if (PlayerDistance < 3f && canAttack)
        {
            animator.SetTrigger("BossMove2Idle");

            if (transform.position.x > PlayerPosition.x)
            {
                key = -1f;
            }
            else if (transform.position.x < PlayerPosition.x)
            {
                key = 1f;
            }
            transform.localScale = new Vector2(9f * key, 9f);
            rigidbody2D.velocity = new Vector2(run * key, rigidbody2D.velocity.y);
            AttackArea.SetActive(true);
            canAttack = false;
            StartCoroutine(attackCoolDown(attackCD));
            StartCoroutine(DisableAfterSeconds(0.1f));
            animator.Play("BossKnifeAttack");
            animator.speed = 0.5f;

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
        Gizmos.DrawWireSphere(transform.position+ground, checkRadius);
        Gizmos.DrawLine(transform.position + new Vector3(raydis * 1, 0, 0), transform.position + new Vector3(raydis * 1, 0, 0) + Vector3.up * rayLength);
        Gizmos.DrawLine(transform.position + new Vector3(BossCollider * -1, 0, 0) + Vector3.up * groundlength, transform.position + new Vector3(BossCollider * -1, 0, 0) + Vector3.down * groundlength);
    }
    private IEnumerator DisableAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds); // 等待指定时间
        if (AttackArea != null)
        {
            AttackArea.SetActive(false); // 禁用攻击范围
        }
    }
    private IEnumerator attackCoolDown(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        canAttack = true;
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{

    //    // Debug.Log("發生碰撞");
    //    if (collision != null && collision.gameObject.CompareTag("Player"))
    //    {
    //        collision.gameObject.GetComponent<PlayerHurt>().Hurt(20f);
    //        Debug.Log("攻擊敵人");
    //    }
    //}
}
