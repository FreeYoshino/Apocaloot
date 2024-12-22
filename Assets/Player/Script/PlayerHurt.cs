using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurt : MonoBehaviour
{
    private Animator animator;              // 動畫
    private GameObject audioController;     // 音效
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void Hurt(float damage)
    {
        CharacterManager.instance.DecreaseHp(damage);   // 扣血
        animator.SetTrigger("Hurt");
    }
}
