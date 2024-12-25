using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterHPController : MonoBehaviour
{
    private const int MaxHealthPerHeart = 33; // 每顆愛心的血量
    private float currentHealth = 99; // 總血量
    private Image[] heartImages; // 愛心圖片陣列（用於填充比例）

    private void Start()
    {
        // 初始化愛心圖片陣列
        Transform canvasTransform = transform.Find("Canvas");
        if (canvasTransform != null)
        {
            Transform bloodTransform = canvasTransform.Find("Blood");
            if (bloodTransform != null)
            {
                heartImages = new Image[bloodTransform.childCount];
                for (int i = 0; i < bloodTransform.childCount; i++)
                {
                    heartImages[i] = bloodTransform.GetChild(i).GetComponent<Image>();
                }
            }
        }

        // 初始化愛心顯示
        UpdateHealthDisplay();
    }

    public void TakeDamage(float damage)
    {
        // 更新總血量
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        // 更新愛心顯示
        UpdateHealthDisplay();

        // 如果血量歸零，觸發死亡
        if (currentHealth == 0)
        {
            Die(gameObject);
        }
    }

    private void UpdateHealthDisplay()
    {
        // 根據當前血量更新每顆愛心的填充比例
        for (int i = 0; i < heartImages.Length; i++)
        {
            // 每顆愛心的血量範圍
            float heartMaxHealth = MaxHealthPerHeart * (i + 1);
            float heartMinHealth = MaxHealthPerHeart * i;

            if (currentHealth >= heartMaxHealth)
            {
                // 如果血量大於等於當前愛心的最大血量，愛心填滿
                heartImages[i].fillAmount = 1f;
            }
            else if (currentHealth > heartMinHealth)
            {
                // 如果血量在當前愛心範圍內，根據比例填充
                heartImages[i].fillAmount = (currentHealth - heartMinHealth) / MaxHealthPerHeart;
            }
            else
            {
                // 如果血量小於當前愛心的最小血量，清空該愛心
                heartImages[i].fillAmount = 0f;
            }
        }
    }

    private void Die(GameObject gameObject)
    {
        // 小怪死亡的處理
        Debug.Log(gameObject.name + " 已死亡");
        Destroy(gameObject); // 刪除小怪物件
    }
}
