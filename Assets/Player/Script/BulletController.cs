using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private float bulletSpeed = 10f;
    private Rigidbody2D rb;
    private Vector3 direction;      // 子彈移動方向
    public GameObject PopUpTextPrefab;    // 彈出文字的Prefab
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void SetDirection(Vector3 direction)
    {
        this.direction = direction;
        rb.velocity = direction * 10;
        // 計算子彈的旋轉角度(對x軸弧度)，轉換為度數
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        // 設置子彈旋轉，將計算的角度應用於子彈的 Z 軸
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
            Debug.Log("發生碰撞");
            if (collision != null && collision.CompareTag("Enemy"))
            {
                Debug.Log("攻擊敵人");
                ShowDamageText(collision.transform);
            }
            Destroy(gameObject);
        }
    }
    private void ShowDamageText(Transform transform)
    {
        GameObject popupText = Instantiate(PopUpTextPrefab);                     // 生成預置體
        GameObject text = popupText.transform.Find("Canvas/Text").gameObject;    // 找到子物件
        popupText.GetComponent<DamageTextController>().SetPosition(transform.position);
        popupText.GetComponent<DamageTextController>().SetDamageText((int)CharacterManager.GetCharacterData().characterPower);
    }
    private void OnBecameInvisible()
    {
        // 子彈超出視野外
        Destroy(gameObject);
    }
}