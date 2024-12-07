using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class IneventoryManager : MonoBehaviour
{
    // ��ҼҦ�
    static IneventoryManager instance;

    public Inventory myBag;
    public GameObject slotGrid;
    public Slot slotPrefab;
    public TMP_Text itemInformation;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(instance);
        }
        instance = this;
    }
}
