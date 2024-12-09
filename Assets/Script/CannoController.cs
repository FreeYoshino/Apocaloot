using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanoController : MonoBehaviour
{
    float CD = 0;
    Animator animator;
    public GameObject CannoBall;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CD += Time.deltaTime;
        if (CD > 2)
        {
            transform.localScale = new Vector2(5f, 5f);
            animator.SetTrigger("BossThrowAttack");
            animator.speed = 0.5f;
            CD = 0;
            GameObject spin = Instantiate(CannoBall); ;
            spin.transform.position = gameObject.transform.position;
        }
    }
}
