using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineBombPU : PowerUps
{
    public GameObject mineBombPrefab;
    public float mineBombExistanceTime;

    public override void PowerUpActivation()
    {
       // SetBombType(BombTypes.stickyBomb);
        SetPowerExistanceTimer(mineBombExistanceTime);
        //GetCharacter().GetComponent<PlayerController>().powerIndicator.SetActive(true);
        base.PowerUpActivation();
    }

    //public override void PowerUpDeactivation()
    //{
    //    GetCharacter().GetComponent<PlayerController>().powerIndicator.SetActive(false);
    //    base.PowerUpDeactivation();
    //}
    public override void PowerUpAction()
    {
        SpawnBomb(mineBombPrefab);
    }
}
