using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BootSceneScript : MonoBehaviour
{
    // 加載MenuScene
    void Start()
    {
        StartCoroutine(WaitSeconds(2f));
        
    }
    private IEnumerator WaitSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds); // 等待指定??
        SceneManager.LoadScene("MenuScene");
    }
}
