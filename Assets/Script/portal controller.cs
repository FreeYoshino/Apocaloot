using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalcontroller : MonoBehaviour
{
    private bool isneardoor = false;
    public Transform backdoor;
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
            CharacterManager.GetCharacterObject().transform.position = backdoor.position;
        }
    }
}
