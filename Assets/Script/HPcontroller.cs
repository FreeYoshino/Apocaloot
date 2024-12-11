using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HPcontroller : MonoBehaviour
{
    GameObject HP;
    GameObject Boss;
    float time=0;
    // Start is called before the first frame update
    void Start()
    {
        HP = GameObject.Find("¦å±ø");
        Boss = GameObject.Find("BOSS");
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 3)
        {
            DecreaseHP();
            BossHurt();
            time -= 5;
        }
        time += Time.deltaTime;


    }
    void DecreaseHP()
    {
        HP.GetComponent<Image>().fillAmount -=0.2f;
    }
    void BossHurt()
    {
        Boss.GetComponent<Animator>().SetTrigger("BossHurt");
    }
}
