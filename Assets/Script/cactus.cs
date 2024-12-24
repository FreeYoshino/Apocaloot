using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cactus : MonoBehaviour
{
    private bool isclose = false;
    public PlayerHurt playerhurt;
    public float damageInterval = 1.0f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isclose = true;
            StartCoroutine(Damage());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isclose = false;
            StopCoroutine(Damage());
        }
    }

    private IEnumerator Damage()
    {
        while (isclose)
        {
            playerhurt.Hurt(5);
            yield return new WaitForSeconds(damageInterval);
        }
    }
}
