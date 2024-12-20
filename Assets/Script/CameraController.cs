using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player;
    private Transform target;
    [SerializeField] private float smooothTime = 0.3f;          //Camera平滑移動的時間
    [SerializeField] private Vector3 offest = new Vector3(0, 3, 0);              //Camera的偏移量
    private Vector3 m_Velocity = Vector3.zero;                  //儲存平滑速度時的速度值

    // 定義邊界(請依據場景在Inspector做更動)
    [SerializeField] private float minX = -10f;                // 相機最左邊界
    [SerializeField] private float maxX = 10f;                 // 相機最右邊界
    [SerializeField] private float minY = -5f;                 // 相機最下邊界
    [SerializeField] private float maxY = 5f;                  // 相機最上邊界
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

    // LateUpdate()確保在角色移動後再進行Camera的移動
    private void LateUpdate()
    {
        Vector3 targetPosition = target.position + offest;         //設定Camera要移動到的位置
        targetPosition.z=-1;
        // 限制相機的目標位置在指定範圍內
        targetPosition.x = Mathf.Clamp(targetPosition.x, minX, maxX);
        targetPosition.y = Mathf.Clamp(targetPosition.y, minY, maxY);

        //使用SmoothDamp平滑移動Camera
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition,ref m_Velocity, smooothTime);
    }
}
