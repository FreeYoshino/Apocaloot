using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HPcontroller : MonoBehaviour
{
    GameObject HP;
    float time=0;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        HP = GameObject.Find("血條");
    }

    // Update is called once per frame
    void Update()
    {


    }
    public void DecreaseHP()
    {
        animator.Play("BossHurt");     // 如果需要可以保留
        HP.GetComponent<Image>().fillAmount -= 0.2f;

        if (HP.GetComponent<Image>().fillAmount <= 0f)
        {
            // 使用 Play 方法直接切換到 "BOSSDIE" 動畫狀態
            animator.Play("BossDie");
            Destroy(gameObject);

        }
        
    }


}
