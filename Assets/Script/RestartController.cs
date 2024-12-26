using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartController : MonoBehaviour
{
    public void EndGameAndReload()
    {
        // 銷毀現有的 Manager
        Destroy(GameObject.Find("GameManager"));
        Destroy(GameObject.Find("CharacterManager"));
        Destroy(GameObject.Find("InventoryManager"));

        // 確保銷毀的物件在下一幀執行前不會被引用
        StartCoroutine(LoadBootScene());
    }

    private IEnumerator LoadBootScene()
    {
        // 避免立即執行切換場景導致的問題，等待一幀
        yield return null;

        // 加載 BootScene
        UnityEngine.SceneManagement.SceneManager.LoadScene("BootScene");
    }

}
