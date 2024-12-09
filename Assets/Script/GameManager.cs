using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // 單例模式
    static GameManager instance;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(instance);
        }
        instance = this;
        DontDestroyOnLoad(gameObject);                          // 確保GameManager可以跨場景
    }

    public static void LoadSceneFirst()
    {
        SceneManager.LoadScene("first");
    }

}
