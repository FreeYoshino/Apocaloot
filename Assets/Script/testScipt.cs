using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testScipt : MonoBehaviour
{
    public GameObject slotGrid;
    // Start is called before the first frame update
    void Start()
    {
        slotGrid = GameObject.Find("Bag/Grid");
        if (slotGrid != null)
        {
            Debug.Log("Work");
        }
        else
        {
            Debug.Log("Not Work");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
