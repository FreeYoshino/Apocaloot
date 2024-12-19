using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalcontroller : MonoBehaviour
{
    private bool isneardoor = false;
    //起點座標位置
    Vector3 startposition = new Vector3(61.13f,22.52f,0f);
    public Transform backdoor;
    public Transform player1;
    public Transform player2;
    public Transform player3;
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isneardoor = true;
        
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isneardoor = false;

        }
    }
    void Update()
    {   
        if (isneardoor == true && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("傳送成功");
            player1.position = backdoor.position;
            player2.position = backdoor.position;
            player3.position = backdoor.position;
        }
    }
}
