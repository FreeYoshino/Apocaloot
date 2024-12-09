using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // ��ҼҦ�
    static GameManager instance;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(instance);
        }
        instance = this;
        DontDestroyOnLoad(gameObject);                          // �T�OGameManager�i�H�����
    }

    public static void LoadSceneFirst()
    {
        SceneManager.LoadScene("first");
    }

}
