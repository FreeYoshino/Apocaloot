using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BootSceneScript : MonoBehaviour
{
    // �[��MenuScene
    void Start()
    {
        StartCoroutine(WaitSeconds(2f));
        
    }
    private IEnumerator WaitSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds); // ���ݫ��w??
        SceneManager.LoadScene("MenuScene");
    }
}
