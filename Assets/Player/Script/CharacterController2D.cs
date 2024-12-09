using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
/**
 * �ѦҸ��:https://github.com/Brackeys/2D-Animation.git
 * �ѦҸ��:https://www.youtube.com/watch?v=dwcT-Dch0bA&t=0s
 * �ܼƫe�� [SerializeField] ��private�ܼƯ�bInspector�������վ�
 */
public class CharacterController2D : MonoBehaviour
{
    [SerializeField] private float m_JumpForce = 250.0f;                 //�]�w���D���O
    [SerializeField] private float m_MovementSmoothing = 0.05f;          //���ʪ����ƫ�
    [SerializeField] private bool m_AirControl = false; //�����O�_��b�Ť��i����V
    [SerializeField] private LayerMask m_WhatIsGround;  //�ŧi�@��"�a��"��Laye Mask, ��{�a���˴����\��
    [SerializeField] private Transform m_GroundCheck;   //�ŧi�@�Ӧa���ˬd�I���ܼ�
    [SerializeField] private Transform m_CeilingCheck;  //�ŧi�@�ӤѪ�O�ˬd�I���ܼ�

    const float k_GroundedRadius = .2f; //�Ψ��˴�����O�_�b�a������θI���b�|
    private bool m_Grounded;            //�P�_����O�_�b�a���W�����L��
    const float k_CeilingRadius = .2f;  //�Ψ��˴������Y���O�_����ê������θI���b�|
    private Rigidbody2D m_Rigidbody2D;  //���⪺ Rigidbody2D�A����⪺���z�欰
    private bool m_FacingRight = true;  //���������e���ª���V�Atrue ��ܦV�k
    private Vector3 m_Velocity = Vector3.zero; //�x�s���Ƴt�׮ɪ��t�׭�

    [Header("Events")]
    [Space]
    public UnityEvent OnLandEvent;
    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }           //�ۭq�q�ƥ�
    private void Awake()                //Awake()�A�Φb���󪺪�l��,�b�����k����e�ե�
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()                  //FixedUpadate()�A�Φb���z�p��
    {
        //�ΨӽT�{����O�_�B�b�踨�a���ƥ�

        bool wasGrounded = m_Grounded;          //�x�s�ثe�O�_�b�a��
        m_Grounded = false;                     //���]�ثe���b�a��

        // Physics2D.OverlapCircleAll �b���w�������I�i�����˴�,�^��Collider2D�}�C,�]�t�b�d�򤺪��Ҧ��I����
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            //�T�O�˴��쪺�I���餣�O���⥻��
            if (colliders[i].gameObject != gameObject)
            {
                m_Grounded = true;
                if (!wasGrounded)               //���e���A���b�a��Ĳ�o�ۦa�ƥ�
                {
                    OnLandEvent.Invoke();       //Invoke()Ĳ�oOnLandEvent�ƥ�,���Ҧ��q�\�o��event����ť���h����������{��
                }
            }
        }
    }

    public void Move(float move, bool jump)     //���Ⲿ�ʪ��禡
    {
        //����u��b�a���W or �}�ҪŤ����� �����p�h�����
        if (m_Grounded || m_AirControl)
        {
            //�]�w���⪺�t��
            Vector3 targetVelocity = new Vector3(move, m_Rigidbody2D.velocity.y);
            //�Q��.SmoothDamp()���ƹL�� �t�ת��ܤ�
            //ref m_Velocity �ϥΰѷӪ��覡�ǻ��ܼ�,�Ψ��x�s�t�ת��ܤ�
            m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

            //���ʤ�V�M���¤�V���@�P,�N½�ਤ�⭱�V
            if (move > 0 && !m_FacingRight)
            {
                Flip();             //�I�sFlip()½�ਤ�⭱�V
            }
            else if (move < 0 && m_FacingRight)
            {
                Flip();             //�I�sFlip()½�ਤ�⭱�V
            }
        }
        //����ݸ��D�����p
        if (m_Grounded && jump)
        {
            //m_Grounded = false;       //�����O�_�b�a�������p,�`:����o�{�o�@�k�|�ϰ_����,�b���a�˴����Q�������a
            m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));       //�I�[�V�W�����D�O
        }
    }
    private void Flip()                         //�Ψ�½�ਤ�⭱�V���禡
    {
        m_FacingRight = !m_FacingRight;         //�������⭱�V

        //�Q�αN���⪺scale��x *-1�F��½�ਤ�⭱�V���ĪG
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
