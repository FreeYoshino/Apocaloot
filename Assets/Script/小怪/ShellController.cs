using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellController : MonoBehaviour
{
    // Start is called before the first frame update
    float speed = 0.5f;
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.speed = speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log("µo¥Í¸I¼²");
        if (collision != null && collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHurt>().Hurt(20f);
            Debug.Log("§ðÀ»¼Ä¤H");
        }
    }
}
