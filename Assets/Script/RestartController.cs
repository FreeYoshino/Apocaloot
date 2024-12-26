using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartController : MonoBehaviour
{
    public void EndGameAndReload()
    {
        // �P���{���� Manager
        Destroy(GameObject.Find("GameManager"));
        Destroy(GameObject.Find("CharacterManager"));
        Destroy(GameObject.Find("InventoryManager"));

        // �T�O�P��������b�U�@�V����e���|�Q�ޥ�
        StartCoroutine(LoadBootScene());
    }

    private IEnumerator LoadBootScene()
    {
        // �קK�ߧY������������ɭP�����D�A���ݤ@�V
        yield return null;

        // �[�� BootScene
        UnityEngine.SceneManagement.SceneManager.LoadScene("BootScene");
    }

}
