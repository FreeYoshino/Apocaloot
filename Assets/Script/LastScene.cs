using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LastScene : MonoBehaviour
{
    private bool isneardoor = false;
    Scene scene;
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
    // Update is called once per frame
    void Update()
    {
        if (isneardoor == true && Input.GetKeyDown(KeyCode.F))
        {
            if (SceneManager.GetActiveScene().name == "SecondScene")
                GameManager.LoadFirstScene();
        }
    }
}
