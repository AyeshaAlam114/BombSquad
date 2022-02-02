using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : BombSpawner
{
    bool once;
    public GameObject bombPrefab;
    GameObject hasBomb;
    PowerUps hittedPowerUp;
    public int health;


    // Start is called before the first frame update
    void Start()
    {
        
        
        once = true;
    }

    // Update is called once per frame
    void Update()
    {
        Die();
    }


    public virtual void AttackByBomb()
    {

    }
    public void GetBomb()
    {
        if (hittedPowerUp != null)
            GetHittedPowerUp().PowerUpAction();
        else
            SpawnBomb(bombPrefab);
        
    }

 

    public void FireBomb()
    {
        this.GetComponent<CharacterController>().ThrowBomb();
    }
    public void SetHealth(int Health)
    {
        health=Health;
    }
    public int GetHealth()
    {
        return health;
    }

    public void GetDamage(int damageByPower)
    {
        health -= damageByPower;
        if (health < 0)
            DieByHit();
    }

    void DieByHit()
    {
        if(this.CompareTag("Player"))
            GetHittedPowerUp().SetCharacter(null);
        DestroyMe();
    }

    public void ThrowBomb()
    {
        if (hasBomb != null)
        {
            Rigidbody bombRb = hasBomb.GetComponent<Rigidbody>();
            bombRb.isKinematic = false;
            bombRb.AddForce(GetCharacter().transform.forward * 500);
            bombRb.transform.parent = null;
        }
       
    }

   public void SetHasBomb(GameObject bomb)
    {
        hasBomb = bomb;
    }
 

    public void SetHittedPowerUp(PowerUps powerUp)
    {
        hittedPowerUp = powerUp;
    }

    public PowerUps GetHittedPowerUp()
    {
       return hittedPowerUp;
    }


    void PunchingAttack()
    {

    }
    void SprintAttack()
    {

    }

    void Die()
    {
        if (once)
        {
            if (transform.position.y < -5)
                DestroyMe();
        }
    }

    void DestroyMe()
    {
        //int i = camera.target.IndexOf(this.gameObject.transform);
        //camera.target.RemoveAt(i);

        Destroy(gameObject);
    }

}
