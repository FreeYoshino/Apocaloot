using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour
{
    public Camera mainCamera;  // 讓你在Inspector中將主攝影機拖到此欄位
    private Vector3 offset;    // 用於記錄背景與鏡頭的偏移量

    // Start is called before the first frame update
    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;  // 如果沒有手動指定，默認使用主攝影機
        }

        // 記錄背景與攝影機之間的初始偏移量
        offset = transform.position - mainCamera.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // 每幀將背景的位置更新為鏡頭的位置加上偏移量
        transform.position = mainCamera.transform.position + offset;
    }
}
