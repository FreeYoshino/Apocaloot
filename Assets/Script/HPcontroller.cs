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
        HP = GameObject.Find("¦å±ø");
    }

    // Update is called once per frame
    void Update()
    {


    }
    public void DecreaseHP()
    {
        animator.SetTrigger("BossMove2Idle");
        animator.SetTrigger("BossHurt");
        HP.GetComponent<Image>().fillAmount -=0.2f;
    }
}
