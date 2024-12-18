using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testScipt : MonoBehaviour
{
    private void Start()
    {
        if(GameObject.Find("Hammer")  == null)
        {
            Debug.Log("Hammer is not work");
        }
    }
}
