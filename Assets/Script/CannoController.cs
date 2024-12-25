using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanoController : MonoBehaviour
{
    float CD = 0;
    Animator animator;
    public GameObject CannoBall;
    float direction;
    float Key;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        direction = transform.localScale.x;
        

    }

    // Update is called once per frame
    void Update()
    {
        if (direction > 0)
        {
            Key = 1;
        }else
        {
            Key = -1;
        }
        CD += Time.deltaTime;
        if (CD > 5)
        {
            transform.localScale = new Vector2(5f * Key, 5f);
            animator.SetTrigger("CannoShoot");
            animator.speed = 2f;
            CD = 0;

            GameObject spin = Instantiate(CannoBall);
            spin.transform.position = transform.position; // 確保子彈從當前物件的位置生成

           
        }

    }
}
