using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private float bulletSpeed = 10f;
    private Rigidbody2D rb;
    private Vector3 direction;      // �l�u���ʤ�V
    public GameObject PopUpTextPrefab;    // �u�X��r��Prefab
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void SetDirection(Vector3 direction)
    {
        this.direction = direction;
        rb.velocity = direction * 10;
        // �p��l�u�����ਤ��(��x�b����)�A�ഫ���׼�
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        // �]�m�l�u����A�N�p�⪺�������Ω�l�u�� Z �b
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
            Debug.Log("�o�͸I��");
            if (collision != null && collision.CompareTag("Enemy"))
            {
                Debug.Log("�����ĤH");
                ShowDamageText(collision.transform);
            }
            Destroy(gameObject);
        }
    }
    private void ShowDamageText(Transform transform)
    {
        GameObject popupText = Instantiate(PopUpTextPrefab);                     // �ͦ��w�m��
        GameObject text = popupText.transform.Find("Canvas/Text").gameObject;    // ���l����
        popupText.GetComponent<DamageTextController>().SetPosition(transform.position);
        popupText.GetComponent<DamageTextController>().SetDamageText((int)CharacterManager.GetCharacterData().characterPower);
    }
    private void OnBecameInvisible()
    {
        // �l�u�W�X�����~
        Destroy(gameObject);
    }
}