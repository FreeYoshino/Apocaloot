using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotemBulletController : MonoBehaviour
{
    GameObject right_border, left_border;
    float speed = -5f; // �l�u�t��
    private Rigidbody2D rb; // Rigidbody2D �ե�

    void Start()
    {
        right_border = GameObject.Find("Right_border");
        left_border = GameObject.Find("Left_border");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(speed, 0);
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

        Debug.Log("�o�͸I��");
        if (collision != null && collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHurt>().Hurt(20f);
            Debug.Log("�����ĤH");
        }
        Destroy(gameObject);
    }
}
