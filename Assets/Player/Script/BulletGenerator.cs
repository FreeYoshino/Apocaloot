using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class BulletGenerator : MonoBehaviour
{
    public GameObject bulletPrefab;                         // �u�Ī�Prefab
    public Transform FirePosition;                          // �l�u���o�g��m
    public void Fire(Vector3 direction)                     
    {
        // �}��
        GameObject bullet = Instantiate(bulletPrefab, FirePosition.position, Quaternion.identity);
        bullet.GetComponent<BulletController>().SetDirection(direction);
    }
}
