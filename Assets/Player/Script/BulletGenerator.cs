using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class BulletGenerator : MonoBehaviour
{
    public GameObject bulletPrefab;                         // 彈藥的Prefab
    public Transform FirePosition;                          // 子彈的發射位置
    public void Fire(Vector3 direction)                     
    {
        // 開火
        GameObject bullet = Instantiate(bulletPrefab, FirePosition.position, Quaternion.identity);
        bullet.GetComponent<BulletController>().SetDirection(direction);
    }
}
