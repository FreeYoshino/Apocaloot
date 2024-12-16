using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DamageTextController : MonoBehaviour
{
    public float floatSpeed = 1.5f;     // �}�B�t��
    public float lifetime = 1.0f;       // ��r�s�b�ɶ�
    public float fadeSpeed = 2.0f;      // �H�X���t��
    private Color color;                // �C��
    private TMP_Text text;              // TMP
    private void Awake()
    {
        text = GetComponentInChildren<TMP_Text>();
        color = text.color;
    }
    private void FixedUpdate()
    {
        transform.Translate(Vector3.up * floatSpeed * Time.deltaTime);      // ��r�}�B�V�W
        color.a -= fadeSpeed * Time.deltaTime;                              // ��r�H�X
        text.color = color;
        if (color.a <= 0)
        {
            // ��r�����z��
            Destroy(gameObject);
        }
    }
    public void SetDamageText(int damage)
    {
        text.text = damage.ToString();
    }
    public void SetPosition(Vector3 poition)
    {
        // �N�@�ɮy���ର�ù��y��
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(poition);
        text.GetComponent<RectTransform>().position = screenPosition;
    }
}
