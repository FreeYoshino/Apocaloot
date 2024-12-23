using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public CharacterAudioController audioController;
    public Animator animator;
    public GameObject myBag;
    public bool isOpen;
    //初始設定角色的橫移速度
    public float runSpeed = 40f;            
    float horizontalMove = 0f;
    bool jump = false;
    bool wasMoving = false;     // 上一禎是否在移動
    private bool isJumping;
    private void OnEnable()                             //物件啟用時自動調用
    {
        //訂閱OnLandEvent事件,並且設定this.OnLanding為調用的函式
        controller.OnLandEvent.AddListener(this.OnLanding);
    }

    private void OnDisable()                             //物件禁用時自動調用
    {
        //取消訂閱OnLandEvent事件
        controller.OnLandEvent.RemoveListener(this.OnLanding);
    }
    void Update()                   
    {
        Movement();
        OpenMyBag();
        PlayAudio();
    }
    void Movement()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;     //獲取水平的輸入並*speed,注:GetAxisRaw("Horizontal")回傳-1 or 0 or 1
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));          //給animator中的Speed值,以切換動畫
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;        //切換跳躍狀態變數
            animator.SetTrigger("isJumping");
        }
    }
    private void OnLanding()
    {
        isJumping = false;
    }

    void OpenMyBag()
    {
        // 打開背包的函式
        if (Input.GetKeyDown(KeyCode.I))
        {
            // 當按下背包鍵切換開啟狀態
            isOpen = !isOpen;
            myBag.SetActive(isOpen);
        }
    }
    private void PlayAudio()
    {
        bool isCurrentMoving = horizontalMove != 0;     // 現在是否要移動
        if (jump && !isJumping)
        {
            isJumping = true;
            audioController.PlayJumpSound();
        }
        if (!isJumping)
        {
            if (isCurrentMoving)
            {
                audioController.PlayWalkSound();
            }
            else if (!isCurrentMoving)
            {
                audioController.StopWalkSound();
            }
        }
    }
    private void FixedUpdate()          //FixedUpadate()適用在物理計算
    {
        //移動角色
        controller.Move(horizontalMove*Time.fixedDeltaTime, jump);
        jump = false;
    }

}
