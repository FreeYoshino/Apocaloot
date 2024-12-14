using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public Slider slider;
    private void Start()
    {
        // 載入時設置血條
        SetMaxHealth(CharacterManager.GetCharacterData().characterMaxHp, CharacterManager.GetCharacterData().characterMaxHp);
    }
    public void SetMaxHealth(float maxHp, float hp)
    {
        // 設置最大血條
        slider.maxValue = maxHp;
        slider.value = hp;
    }
    public void SetHealth(float health)
    {
        slider.value = health;
    }
}
