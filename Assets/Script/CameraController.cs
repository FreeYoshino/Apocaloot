using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player;
    private Transform target;
    [SerializeField] private float smooothTime = 0.3f;          //Camera平滑移動的時間
    private Vector3 offest = new Vector3(0, 3, 0);              //Camera的偏移量
    private Vector3 m_Velocity = Vector3.zero;                  //儲存平滑速度時的速度值
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Archer");
        target = player.transform; 

    }

    // LateUpdate()確保在角色移動後再進行Camera的移動
    private void LateUpdate()
    {
        Vector3 targetPosition = new Vector3(transform.position.x,target.position.y+offest.y, transform.position.z);         //設定Camera要移動到的位置

        //使用SmoothDamp平滑移動Camera
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition,ref m_Velocity, smooothTime);
    }
}
