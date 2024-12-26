using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HPcontroller : MonoBehaviour
{
    GameObject HP;
    float time=0;
    float bosshp = 250f;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        HP = GameObject.Find("���");
    }

    // Update is called once per frame
    void Update()
    {


    }
    public void DecreaseHP(float damage)
    {
        float hurt = damage / bosshp;
        animator.Play("BossHurt");     // �p�G�ݭn�i�H�O�d
        HP.GetComponent<Image>().fillAmount -= hurt;

        if (HP.GetComponent<Image>().fillAmount <= 0f)
        {
            // �ϥ� Play ��k���������� "BOSSDIE" �ʵe���A
            animator.Play("BossDie");
            Destroy(gameObject);
            GameManager.instance.GameOver(true);
        }
        
    }


}
