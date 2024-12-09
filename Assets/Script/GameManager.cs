using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // ��ҼҦ�
    static GameManager instance;

    [Header("Events")]
    [Space]
    public UnityEvent OnLoadScene;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(instance);
        }
        instance = this;
        DontDestroyOnLoad(gameObject);                          // �T�OGameManager�i�H�����
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        // �����q�\�����[���^��
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "first")
        {
            OnLoadScene.Invoke();
        }
    }

    public static void LoadSceneFirst()
    {
        SceneManager.LoadScene("first");
    }

}
