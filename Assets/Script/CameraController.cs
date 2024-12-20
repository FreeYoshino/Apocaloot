using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player;
    private Transform target;
    [SerializeField] private float smooothTime = 0.3f;          //Camera���Ʋ��ʪ��ɶ�
    [SerializeField] private Vector3 offest = new Vector3(0, 3, 0);              //Camera�������q
    private Vector3 m_Velocity = Vector3.zero;                  //�x�s���Ƴt�׮ɪ��t�׭�

    // �w�q���(�Ш̾ڳ����bInspector�����)
    [SerializeField] private float minX = -10f;                // �۾��̥����
    [SerializeField] private float maxX = 10f;                 // �۾��̥k���
    [SerializeField] private float minY = -5f;                 // �۾��̤U���
    [SerializeField] private float maxY = 5f;                  // �۾��̤W���
    // Start is called before the first frame update
    void Start()
    {
        // player = GameObject.FindGameObjectWithTag("Player");
        player = CharacterManager.GetCharacterObject();
        if (player != null)
        {
            // Debug.Log("CameraController work");
        }
        target = player.transform; 

    }

    // LateUpdate()�T�O�b���Ⲿ�ʫ�A�i��Camera������
    private void LateUpdate()
    {
        Vector3 targetPosition = target.position + offest;         //�]�wCamera�n���ʨ쪺��m
        targetPosition.z=-1;
        // ����۾����ؼЦ�m�b���w�d��
        targetPosition.x = Mathf.Clamp(targetPosition.x, minX, maxX);
        targetPosition.y = Mathf.Clamp(targetPosition.y, minY, maxY);

        //�ϥ�SmoothDamp���Ʋ���Camera
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition,ref m_Velocity, smooothTime);
    }
}
