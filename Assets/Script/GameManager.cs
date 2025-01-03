using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // 單例模式
    public static GameManager instance;
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
                    character.characterTimeToAttack = 0.5f;
                    break;
                case CharacterData.CharacterType.Shooter:
                    character.characterMaxHp = 80f;
                    character.characterHp = character.characterMaxHp;
                    character.characterPower = 20f;
                    character.characterTimeToAttack = 0.5f;
                    break;
                case CharacterData.CharacterType.Hammer:
                    character.characterMaxHp = 300f;
                    character.characterHp = character.characterMaxHp;
                    character.characterPower = 10f;
                    character.characterTimeToAttack = 0.25f;
                    break;
            }
        }
    }

    public void SetCharacterActive()
    {
        CharacterData character = CharacterManager.GetCharacterData();
        for (int i = 0; i < allCharacter.Length; i++)
        {
            if (allCharacter[i].characterType == character.characterType)
            {
                continue;
            }
            GameObject.Find(allCharacter[i].characterName).SetActive(false);
            Debug.Log(allCharacter[i].characterName);
        }
    }
    private void OnDestroy()
    {
        // 取消訂閱場景加載回調
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "FirstScene" || scene.name == "SecondScene" || scene.name == "BOSS_Scene")
        {
            OnLoadScene.Invoke();
        }
    }
    public void GameOver(bool result)
    {
        if (result)
        {
            // 勝利
            SceneManager.LoadScene("victor");
        }
        else
        {
            // 失敗
            SceneManager.LoadScene("failure");
            Debug.Log("角色死亡,遊戲失敗");
        }
    }
    public static void LoadFirstScene()
    {
        SceneManager.LoadScene("FirstScene");
    }
    public static void LoadSecondScene()
    {
        SceneManager.LoadScene("SecondScene");
    }
    public static void LoadBossScene()
    {
        SceneManager.LoadScene("Boss_Scene");
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("BootScene");
    }
}
