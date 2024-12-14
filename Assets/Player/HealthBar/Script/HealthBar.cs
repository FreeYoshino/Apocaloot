using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public Slider slider;
    private void Start()
    {
        // ���J�ɳ]�m���
        SetMaxHealth(CharacterManager.GetCharacterData().characterMaxHp, CharacterManager.GetCharacterData().characterMaxHp);
    }
    public void SetMaxHealth(float maxHp, float hp)
    {
        // �]�m�̤j���
        slider.maxValue = maxHp;
        slider.value = hp;
    }
    public void SetHealth(float health)
    {
        slider.value = health;
    }
}
