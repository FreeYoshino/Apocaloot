using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalcontroller : MonoBehaviour
{
    private bool isneardoor = false;
    //�_�I�y�Ц�m
    Vector3 startposition = new Vector3(61.13f,22.52f,0f);  
    GameObject plarer;
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
            Debug.Log("�ǰe���\");    
        }
    }
}
