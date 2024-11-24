using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    //初始設定角色的橫移速度
    public float runSpeed = 40f;            
    float horizontalMove = 0f;
    bool jump = false;
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
    void Update()                   //用於輸入檢測的非物理更新邏輯
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;     //獲取水平的輸入並*speed,注:GetAxisRaw("Horizontal")回傳-1 or 0 or 1
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));          //給animator中的Speed值,以切換動畫

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;        //切換跳躍狀態變數
            animator.SetBool("isJumping", true);
        }
    }

    private void OnLanding()
    {
        animator.SetBool("isJumping", false);
    }

    private void FixedUpdate()          //FixedUpadate()適用在物理計算
    {
        //移動角色
        controller.Move(horizontalMove*Time.fixedDeltaTime, jump);
        jump = false;
    }
}
