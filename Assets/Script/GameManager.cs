using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // 單例模式
    static GameManager instance;
    public CharacterData[] allCharacter;
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
        DontDestroyOnLoad(gameObject);                          // 確保GameManager可以跨場景
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnEnable()
    {
        InitAllCharacterData();
    }
    private void InitAllCharacterData()
    {
        for (int i = 0; i < allCharacter.Length; i++) 
        {
            CharacterData character = allCharacter[i];
            switch (character.characterType)
            {
                case CharacterData.CharacterType.Archer:
                    character.characterMaxHp = 100f;
                    character.characterHp = character.characterMaxHp;
                    character.characterPower = 15f;
                    break;
                case CharacterData.CharacterType.Shooter:
                    character.characterMaxHp = 80f;
                    character.characterHp = character.characterMaxHp;
                    character.characterPower = 10f;
                    break;
                case CharacterData.CharacterType.Hammer:
                    character.characterMaxHp = 150f;
                    character.characterHp = character.characterMaxHp;
                    character.characterPower = 10;
                    break;
            }
        }
    }
    private void OnDestroy()
    {
        // 取消訂閱場景加載回調
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "first")
        {
            OnLoadScene.Invoke();
        }
    }

    public static void LoadFirstScene()
    {
        SceneManager.LoadScene("first");
    }

}
