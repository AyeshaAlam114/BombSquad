using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : BombSpawner
{
    float powerExistingTime;

    public enum PowerUpTypes{multiBomb,stickyBomb ,mineBomb,LifeUp};
    public PowerUpTypes bombtype;

    // Start is called before the first frame update
    void Start()
    {

    }
    public virtual void PowerUpActivation()
    {
        StartCoroutine(CoroutineTimer());
        this.GetComponent<MeshRenderer>().enabled = false;
        this.GetComponent<BoxCollider>().enabled = false;

    }
    public virtual void PowerUpDeactivation()
    {
        GetCharacter().SetHittedPowerUp(null);
        DestroyPowerUp();
    }

    void DestroyPowerUp()
    {
        Destroy(gameObject);
    }

    public virtual void PowerUpAction()
    {
       
    }

    public void SetBombType(PowerUpTypes BombType)
    {
        bombtype=BombType;
    }

    public void SetPowerExistanceTimer(float PowerExistingTime)
    {
        powerExistingTime = PowerExistingTime;
    }
 

   

    IEnumerator CoroutineTimer()
    {
        yield return new WaitForSeconds(powerExistingTime);
        PowerUpDeactivation();
    }

  

    // Update is called once per frame
    void Update()
    {
        
    }
}
