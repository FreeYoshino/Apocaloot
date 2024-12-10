using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public GameObject myBag;
    public bool isOpen;
    //��l�]�w���⪺��t��
    public float runSpeed = 40f;            
    float horizontalMove = 0f;
    bool jump = false;
    
    private void OnEnable()                             //����ҥήɦ۰ʽե�
    {
        //�q�\OnLandEvent�ƥ�,�åB�]�wthis.OnLanding���եΪ��禡
        controller.OnLandEvent.AddListener(this.OnLanding);
    }

    private void OnDisable()                             //����T�ήɦ۰ʽե�
    {
        //�����q�\OnLandEvent�ƥ�
        controller.OnLandEvent.RemoveListener(this.OnLanding);
    }
    void Update()                   
    {
        Movement();
        OpenMyBag();

        // ���դ�������
        if (Input.GetKeyDown(KeyCode.C)) 
        {
            GameManager.LoadSceneFirst();
        } 
        // ���տ�X������
        if (Input.GetKeyDown(KeyCode.B))
        {
            CharacterManager.PrintCharacterData();
        }
        // ���ը���Data�ܰ�
        if (Input.GetKeyDown(KeyCode.V))
        {

        }
    }
    void Movement()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;     //�����������J��*speed,�`:GetAxisRaw("Horizontal")�^��-1 or 0 or 1
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));          //��animator����Speed��,�H�����ʵe

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;        //�������D���A�ܼ�
            animator.SetBool("isJumping", true);
        }
    }
    private void OnLanding()
    {
        animator.SetBool("isJumping", false);
    }

    void OpenMyBag()
    {
        // ���}�I�]���禡
        if (Input.GetKeyDown(KeyCode.I))
        {
            // �����U�I�]������}�Ҫ��A
            isOpen = !isOpen;
            myBag.SetActive(isOpen);
        }
    }

    private void FixedUpdate()          //FixedUpadate()�A�Φb���z�p��
    {
        //���ʨ���
        controller.Move(horizontalMove*Time.fixedDeltaTime, jump);
        jump = false;
    }

}