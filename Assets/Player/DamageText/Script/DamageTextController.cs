using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DamageTextController : MonoBehaviour
{
    public float floatSpeed = 1.5f;     // 漂浮速度
    public float lifetime = 1.0f;       // 文字存在時間
    public float fadeSpeed = 2.0f;      // 淡出的速度
    private Color color;                // 顏色
    private TMP_Text text;              // TMP
    private void Awake()
    {
        text = GetComponentInChildren<TMP_Text>();
        color = text.color;
    }
    private void FixedUpdate()
    {
        transform.Translate(Vector3.up * floatSpeed * Time.deltaTime);      // 文字漂浮向上
        color.a -= fadeSpeed * Time.deltaTime;                              // 文字淡出
        text.color = color;
        if (color.a <= 0)
        {
            // 文字完全透明
            Destroy(gameObject);
        }
    }
    public void SetDamageText(int damage)
    {
        text.text = damage.ToString();
    }
    public void SetPosition(Vector3 poition)
    {
        // 將世界座標轉為螢幕座標
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(poition);
        text.GetComponent<RectTransform>().position = screenPosition;
    }
}
