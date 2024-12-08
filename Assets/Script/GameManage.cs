using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManage : MonoBehaviour
{
  
    GameObject player;
    void Start()
    {
        player = GameObject.Find("Archer");
    }

    
    void Update()
    {
        Vector2 playerPos = player.transform.position;
        transform.position = new Vector2(playerPos.x, playerPos.y);
    }
}
