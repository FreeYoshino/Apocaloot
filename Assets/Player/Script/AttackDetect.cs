using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDetect : MonoBehaviour
{
    public GameObject PopUpTextPrefab;    // �u�X��r��Prefab
    // �l�l�������P�_
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<MonsterHPController>().TakeDamage(CharacterManager.GetCharacterData().characterPower);
            ShowDamageText(collision.transform);
        }
        if (collision != null && collision.CompareTag("BOSS"))
        {
            collision.gameObject.GetComponent<HPcontroller>().DecreaseHP(CharacterManager.GetCharacterData().characterPower);
            ShowDamageText(collision.transform);
        }
    }
    private void ShowDamageText(Transform transform)
    {
        GameObject popupText = Instantiate(PopUpTextPrefab);                     // �ͦ��w�m��
        GameObject text = popupText.transform.Find("Canvas/Text").gameObject;    // ���l����
        popupText.GetComponent<DamageTextController>().SetPosition(transform.position);
        popupText.GetComponent<DamageTextController>().SetDamageText((int)CharacterManager.GetCharacterData().characterPower);
    }
}
