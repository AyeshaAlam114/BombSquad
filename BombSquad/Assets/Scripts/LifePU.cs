using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePU : PowerUps
{
    public int lifeIncrement;
    public float lifeUpExistanceTime;

    public override void PowerUpActivation()
    {
       // SetBombType(BombTypes.LifeUp);
        SetPowerExistanceTimer(lifeUpExistanceTime);
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
        GetCharacter().SetHealth(GetCharacter().GetHealth()+ lifeIncrement);
    }
}
