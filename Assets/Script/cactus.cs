using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cactus : MonoBehaviour
{
    private bool isclose = false;
    public float damageInterval = 1.0f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isclose = true;
            StartCoroutine(Damage(collision));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isclose = false;
            StopCoroutine(Damage(collision));
        }
    }

    private IEnumerator Damage(Collider2D collision)
    {
        while (isclose)
        {
            collision.gameObject.GetComponent<PlayerHurt>().Hurt(5f);
            yield return new WaitForSeconds(damageInterval);
        }
    }
}
