using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BootSceneScript : MonoBehaviour
{
    // ¥[¸üMenuScene
    void Start()
    {
        SceneManager.LoadScene("MenuScene");
    }

}
