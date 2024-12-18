using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotemBulletControllerR : MonoBehaviour
{
    GameObject right_border, left_border;
    float speed = 5f; // 子彈速度
    private Rigidbody2D rb; // Rigidbody2D 組件

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
}
