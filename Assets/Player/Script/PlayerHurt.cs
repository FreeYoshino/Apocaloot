using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurt : MonoBehaviour
{
    private Animator animator;              // �ʵe
    private CharacterAudioController audioController;     // ����
    private void Start()
    {
        animator = GetComponent<Animator>();
        audioController = GetComponent<CharacterAudioController>();
    }
    public void Hurt(float damage)
    {
        CharacterManager.instance.DecreaseHp(damage);   // ����
        animator.SetTrigger("Hurt");
        audioController.PlayHurtSound();
    }
}
