using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class 小怪血量Controller : MonoBehaviour
{
    public void TakeDamage(int currentHealth, GameObject[] heartImages,GameObject gameObject)
    {
        currentHealth -= 1;
        if (currentHealth < 0)
            currentHealth = 0;

        UpdateHealthDisplay(currentHealth, heartImages);

        if (currentHealth == 0)
        {
            Die(gameObject);
        }
    }

    public void UpdateHealthDisplay(int currentHealth, GameObject[] heartImages)
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
