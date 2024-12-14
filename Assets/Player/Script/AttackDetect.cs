using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDetect : MonoBehaviour
{
    // 槌子攻擊的判斷
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
            Debug.Log("發生碰撞");
            if (collision != null && collision.CompareTag("Enemy"))
            {
                Debug.Log("攻擊敵人");
            }
            Destroy(gameObject);
        }
    }
}
