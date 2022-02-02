using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyBombPU : PowerUps
{
    public GameObject stickyBombPrefab;
    public float stickyBombExistanceTime;

    public override void PowerUpActivation()
    {
       // SetBombType(BombTypes.stickyBomb);
        SetPowerExistanceTimer(stickyBombExistanceTime);
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
        SpawnBomb(stickyBombPrefab);
    }
}
