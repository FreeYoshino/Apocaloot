using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MonsterHPController : MonoBehaviour
{
    int currentHealth;
    private GameObject[] heartImages;     // 愛心圖片陣列
    private void Start()
    {
        currentHealth = 3;
        Transform canvasTransform = transform.Find("Canvas");
        if (canvasTransform != null)
        {
            Transform bloodTransform = canvasTransform.Find("Blood");
            if (bloodTransform != null)
            {
                heartImages = new GameObject[bloodTransform.childCount];
                for (int i = 0; i < bloodTransform.childCount; i++)
                {
                    heartImages[i] = bloodTransform.GetChild(i).gameObject;
                }
            }
        }
        //以上處理血量
    }
    public void TakeDamage()
    {
        currentHealth -= 1;
        if (currentHealth < 0)
            currentHealth = 0;

        UpdateHealthDisplay();

        if (currentHealth == 0)
        {
            Die(gameObject);
        }
    }

    public void UpdateHealthDisplay()
    {
        // 根據當前血量顯示或隱藏愛心圖片
        for (int i = 0; i < heartImages.Length; i++)
        {
            heartImages[i].SetActive(i < currentHealth); // 顯示或隱藏愛心
        }
    }

    public void Die(GameObject gameObject)
    {
        // 小怪死亡的處理
        Debug.Log(gameObject.name + " 已死亡");
        Destroy(gameObject); // 刪除小怪
    }
}
