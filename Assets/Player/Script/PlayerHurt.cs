using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurt : MonoBehaviour
{
    private Animator animator;              // °Êµe
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void Hurt(float damage)
    {
        CharacterManager.instance.DecreaseHp(damage);   // ¦©¦å
        animator.SetTrigger("Hurt");
    }
}
