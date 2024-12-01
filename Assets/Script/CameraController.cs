using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player;
    private Transform target;
    [SerializeField] private float smooothTime = 0.3f;          //Camera���Ʋ��ʪ��ɶ�
    private Vector3 offest = new Vector3(0, 3, 0);              //Camera�������q
    private Vector3 m_Velocity = Vector3.zero;                  //�x�s���Ƴt�׮ɪ��t�׭�
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Archer");
        target = player.transform; 

    }

    // LateUpdate()�T�O�b���Ⲿ�ʫ�A�i��Camera������
    private void LateUpdate()
    {
        Vector3 targetPosition = new Vector3(transform.position.x,target.position.y+offest.y, transform.position.z);         //�]�wCamera�n���ʨ쪺��m

        //�ϥ�SmoothDamp���Ʋ���Camera
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition,ref m_Velocity, smooothTime);
    }
}
