using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackDetect : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHurt>().Hurt(20f);
        }
    }
}
