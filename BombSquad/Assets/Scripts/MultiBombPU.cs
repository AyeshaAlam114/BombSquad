using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiBombPU : PowerUps
{
    public GameObject multiBombPrefab;
    public float multiBombExistanceTime;

    public override void PowerUpActivation()
    {
       // SetBombType(BombTypes.multiBomb);
        SetPowerExistanceTimer(multiBombExistanceTime);
        GetCharacter().GetComponent<PlayerController>().powerIndicator.SetActive(true);
        base.PowerUpActivation();
    }

    public override void PowerUpDeactivation()
    {
        GetCharacter().GetComponent<PlayerController>().powerIndicator.SetActive(false);
        base.PowerUpDeactivation();
    }
    public override void PowerUpAction()
    {
        SpawnBomb(multiBombPrefab);
    }
}
