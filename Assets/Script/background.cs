using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour
{
    public Camera mainCamera;  // ���A�bInspector���N�D��v����즹���
    private Vector3 offset;    // �Ω�O���I���P���Y�������q

    // Start is called before the first frame update
    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;  // �p�G�S����ʫ��w�A�q�{�ϥΥD��v��
        }

        // �O���I���P��v����������l�����q
        offset = transform.position - mainCamera.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // �C�V�N�I������m��s�����Y����m�[�W�����q
        transform.position = mainCamera.transform.position + offset;
    }
}
