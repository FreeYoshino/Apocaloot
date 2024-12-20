using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public void OnOkButtonClicked()
    {
        GameManager.LoadFirstScene();
    }

    public void LoadFirstScene()
    {
        GameManager.LoadFirstScene();
    }
    public void LoadSecondScene()
    {
        GameManager.LoadSecondScene();
    }
    public void LoadBossScene()
    {
        GameManager.LoadBossScene();
    }
    public void PlayerHurt()
    {
        GameObject player = CharacterManager.GetCharacterObject();
        player.GetComponent<PlayerHurt>().Hurt(10f);
    }
}
