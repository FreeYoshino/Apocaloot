using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testScipt : MonoBehaviour
{
    private void Start()
    {
        InventoryManager.instance.GetRandomItem();
    }
}
