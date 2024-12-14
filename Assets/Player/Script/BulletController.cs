using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float bulletSpeed = 10f;
    private Rigidbody2D rb;
    private float direction;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = Mathf.Sign(CharacterManager.GetCharacterObject().transform.localScale.x);
    }

    private void Start()
    {
        rb.velocity = new Vector2(bulletSpeed * direction, 0);
        transform.localScale = new Vector3(direction*transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
            Debug.Log("µo¥Í¸I¼²");
            if (collision != null && collision.CompareTag("Enemy"))
            {
                Debug.Log("§ðÀ»¼Ä¤H");
            }
            Destroy(gameObject);
        }
        
    }
}