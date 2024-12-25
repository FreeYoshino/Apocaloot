using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDetect : MonoBehaviour
{
    public GameObject PopUpTextPrefab;    // 彈出文字的Prefab
    // 槌子攻擊的判斷
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
        GameObject popupText = Instantiate(PopUpTextPrefab);                     // 生成預置體
        GameObject text = popupText.transform.Find("Canvas/Text").gameObject;    // 找到子物件
        popupText.GetComponent<DamageTextController>().SetPosition(transform.position);
        popupText.GetComponent<DamageTextController>().SetDamageText((int)CharacterManager.GetCharacterData().characterPower);
    }
}
