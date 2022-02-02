using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    GameObject SpawnedBomb;
    CharacterController character;

    public void SpawnBomb(GameObject bombPrefab)
    {
        SpawnedBomb = Instantiate(bombPrefab, SetBombPosition(), Quaternion.identity, character.transform);
        character.SetHasBomb(SpawnedBomb);
    }


    Vector3 SetBombPosition()
    {
        return new Vector3(character.transform.position.x,
                            character.transform.position.y + 3,
                            character.transform.position.z);
    }

    public void SetCharacter(CharacterController Character)
    {
        character = Character;
    }
    public CharacterController GetCharacter()
    {
        return character;
    }
}
