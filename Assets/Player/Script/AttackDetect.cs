using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDetect : MonoBehaviour
{
    // �l�l�������P�_
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
