using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPcontroller : MonoBehaviour
{
    GameObject HP;
    float time=0;
    // Start is called before the first frame update
    void Start()
    {
        HP = GameObject.Find("¦å±ø");
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 5)
        {
            DecreaseHP();
            time -= 5;
        }
        time += Time.deltaTime;
        
        
    }
    void DecreaseHP()
    {
        HP.GetComponent<Image>().fillAmount -=0.2f;
    }
}
