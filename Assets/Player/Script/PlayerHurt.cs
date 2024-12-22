using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurt : MonoBehaviour
{
    private Animator animator;              // 動畫
    private CharacterAudioController audioController;     // 音效
    private void Start()
    {
        animator = GetComponent<Animator>();
        audioController = GetComponent<CharacterAudioController>();
    }
    public void Hurt(float damage)
    {
        CharacterManager.instance.DecreaseHp(damage);   // 扣血
        animator.SetTrigger("Hurt");
        audioController.PlayHurtSound();
    }
}
