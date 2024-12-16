using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private float bulletSpeed = 10f;
    private Rigidbody2D rb;
    private Vector3 direction;      // �l�u���ʤ�V
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void SetDirection(Vector3 direction)
    {
        this.direction = direction;
        rb.velocity = direction * 10;
        // �p��l�u�����ਤ��(��x�b����)�A�ഫ���׼�
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        // �]�m�l�u����A�N�p�⪺�������Ω�l�u�� Z �b
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
            Debug.Log("�o�͸I��");
            if (collision != null && collision.CompareTag("Enemy"))
            {
                Debug.Log("�����ĤH");
            }
            Destroy(gameObject);
        }
        
    }
}