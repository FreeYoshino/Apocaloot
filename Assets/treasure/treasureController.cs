using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treasureController : MonoBehaviour
{
    public int index;
    public GameObject treasureQA;
    public checkAnswer controller;
    private bool isneartreasure = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isneartreasure = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isneartreasure = false;
            treasureQA.SetActive(false);
        }
    }
    void Update()
    {
        if (isneartreasure == true && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("開啟寶箱");
            treasureQA.SetActive(true);
            controller.DisplayRandomQuestion();
        }
    }
    public void onButtonClick()
    {
        controller.CheckAnswer(index);
    }
}
