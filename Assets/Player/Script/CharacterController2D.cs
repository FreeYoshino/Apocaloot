using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
/**
 * 參考資料:https://github.com/Brackeys/2D-Animation.git
 * 參考資料:https://www.youtube.com/watch?v=dwcT-Dch0bA&t=0s
 * 變數前綴 [SerializeField] 讓private變數能在Inspector中直接調整
 */
public class CharacterController2D : MonoBehaviour
{
    [SerializeField] private float m_JumpForce = 250.0f;                 //設定跳躍的力
    [SerializeField] private float m_MovementSmoothing = 0.05f;          //移動的平滑度
    [SerializeField] private bool m_AirControl = false; //控制角色是否能在空中進行轉向
    [SerializeField] private LayerMask m_WhatIsGround;  //宣告一個"地面"的Laye Mask, 實現地面檢測的功能
    [SerializeField] private Transform m_GroundCheck;   //宣告一個地面檢查點的變數
    [SerializeField] private Transform m_CeilingCheck;  //宣告一個天花板檢查點的變數

    const float k_GroundedRadius = .2f; //用來檢測角色是否在地面的圓形碰撞半徑
    private bool m_Grounded;            //判斷角色是否在地面上的布林值
    const float k_CeilingRadius = .2f;  //用來檢測角色頭頂是否有障礙物的圓形碰撞半徑
    private Rigidbody2D m_Rigidbody2D;  //角色的 Rigidbody2D，控制角色的物理行為
    private bool m_FacingRight = true;  //紀錄角色當前面朝的方向，true 表示向右
    private Vector3 m_Velocity = Vector3.zero; //儲存平滑速度時的速度值

    [Header("Events")]
    [Space]
    public UnityEvent OnLandEvent;
    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }           //自訂義事件
    private void Awake()                //Awake()適用在元件的初始化,在任何方法執行前調用
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()                  //FixedUpadate()適用在物理計算
    {
        //用來確認角色是否處在剛落地的事件

        bool wasGrounded = m_Grounded;          //儲存目前是否在地面
        m_Grounded = false;                     //假設目前不在地面

        // Physics2D.OverlapCircleAll 在給定的中心點進行圓形檢測,回傳Collider2D陣列,包含在範圍內的所有碰撞體
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            //確保檢測到的碰撞體不是角色本身
            if (colliders[i].gameObject != gameObject)
            {
                m_Grounded = true;
                if (!wasGrounded)               //先前狀態不在地面觸發著地事件
                {
                    OnLandEvent.Invoke();       //Invoke()觸發OnLandEvent事件,讓所有訂閱這個event的監聽器去執行對應的程式
                }
            }
        }
    }

    public void Move(float move, bool jump)     //角色移動的函式
    {
        //角色只能在地面上 or 開啟空中控制 的情況去控制角色
        if (m_Grounded || m_AirControl)
        {
            //設定角色的速度
            Vector3 targetVelocity = new Vector3(move, m_Rigidbody2D.velocity.y);
            //利用.SmoothDamp()平滑過度 速度的變化
            //ref m_Velocity 使用參照的方式傳遞變數,用來儲存速度的變化
            m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

            //移動方向和面朝方向不一致,將翻轉角色面向
            if (move > 0 && !m_FacingRight)
            {
                Flip();             //呼叫Flip()翻轉角色面向
            }
            else if (move < 0 && m_FacingRight)
            {
                Flip();             //呼叫Flip()翻轉角色面向
            }
        }
        //角色需跳躍的情況
        if (m_Grounded && jump)
        {
            //m_Grounded = false;       //切換是否在地面的情況,注:實測發現這作法會使起跳時,在落地檢測中被視為落地
            m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));       //施加向上的跳躍力
        }
    }
    private void Flip()                         //用來翻轉角色面向的函式
    {
        m_FacingRight = !m_FacingRight;         //切換角色面向

        //利用將角色的scale的x *-1達到翻轉角色面向的效果
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
