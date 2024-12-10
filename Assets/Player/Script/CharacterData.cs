using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New CharacterData", menuName = "Character/New CharacterData")]
public class CharacterData : ScriptableObject
{
    public string characterName;
    public float characterMaxHp;
    public float characterHp;
    public float characterPower;
}
