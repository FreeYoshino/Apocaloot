using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    public CharacterData characterData;
    public void CharacterOnSelected()
    {
        CharacterManager.InitializeCharacterData(characterData);
    }

}
