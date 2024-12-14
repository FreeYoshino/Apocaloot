using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class BulletGenerator : MonoBehaviour
{
    public GameObject arrowPrefab, bulletPrefab;
    public void Fire()
    {
        // ¶}¤õ
        Vector3 position = CharacterManager.GetCharacterObject().transform.position;
        switch (CharacterManager.GetCharacterData().characterType)
        {
            case CharacterData.CharacterType.Archer:
                Instantiate(arrowPrefab, position, Quaternion.identity);
                break;
            case CharacterData.CharacterType.Shooter:
                Instantiate(bulletPrefab, position, Quaternion.identity);
                break;
        }
    }
}
