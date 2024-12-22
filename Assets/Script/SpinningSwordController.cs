using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningSwordController : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject boss, Player;
    GameObject right_border, left_border;
    float flyForce = 100f;
    float MaxSpeed = 6f;
    float direction;
    float time;
    float speed = 150f;
    Rigidbody2D rb;
    void Start()
    {
        boss = GameObject.Find("BOSS");
        right_border = GameObject.Find("right_border");
        left_border = GameObject.Find("left_border");
        //Player = GameObject.Find("Player");
        direction = boss.transform.localScale.x;
        gameObject.transform.localScale = new Vector2(direction, 5f);
        rb = GetComponent<Rigidbody2D>();
        if (direction > 0)
            rb.velocity = new Vector2(MaxSpeed,0);
        else
            rb.velocity = new Vector2(-MaxSpeed,0);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x > right_border.transform.position.x)
        {
            Destroy(gameObject);
        }
        if (gameObject.transform.position.x < left_border.transform.position.x)
        {
            Destroy(gameObject);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log("µo¥Í¸I¼²");
        if (collision != null && collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHurt>().Hurt(20f);
            Debug.Log("§ðÀ»¼Ä¤H");
        }
        Destroy(gameObject);
    }
}
