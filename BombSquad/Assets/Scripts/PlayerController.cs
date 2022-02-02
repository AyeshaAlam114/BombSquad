using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharacterController
{
    public float moveSpeed;
    public float rotationSpeed;
    // public Transform focalPosition;
    public GameObject powerIndicator;
    Rigidbody playerRb;
    Animator playerAnim;

    public int multiBombRange;
    public bool hasPowerUp;


    // Start is called before the first frame update
    void Start()
    {
        hasPowerUp = false;
        SetCharacter(this);
        SetHittedPowerUp( null);
        SetHealth(20);
        playerAnim = gameObject.GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody>();
        powerIndicator.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        if (GetHittedPowerUp() != null)
            AttackWithPowerUps();
        else
            AttackByBomb();

    }

    void AttackWithPowerUps()
    {
        if (GetHittedPowerUp().bombtype == PowerUps.PowerUpTypes.multiBomb)
            AttackByMultiBomb();
        else
            AttackByBomb();
    }
    public override void AttackByBomb()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            GetBomb();
        if (Input.GetKeyUp(KeyCode.Space))
            FireBomb();
    }
    void AttackByMultiBomb()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetBomb();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            FireBomb();
            for (int i = 0; i < multiBombRange - 2; i++)
            BombWithAutoFire();
        }
            

    }
    void BombWithAutoFire()
    {
        GetBomb();
        Invoke(nameof(FireBomb), 0.1f);
    }

   
    void Movement()
    {
       
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        if (verticalInput == 0 && horizontalInput == 0)
            playerAnim.SetFloat("Speed_f", 0.1f);
        else
            playerAnim.SetFloat("Speed_f", 0.3f);

        playerRb.AddForce(transform.forward * verticalInput * moveSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime * horizontalInput);

    }


    void AfterCollectingPowerUp(Collider powerUp)
    {
        SetHittedPowerUp(powerUp.GetComponent<PowerUps>());
        if (GetHittedPowerUp() != null)
        {
            GetHittedPowerUp().SetCharacter(this);
            GetHittedPowerUp().PowerUpActivation();
        }
 
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("powerUp"))
        AfterCollectingPowerUp(other);
      
    }

    private void OnCollisionEnter(Collision collision)
    {
        float powerUpStrength = 10;
        if(collision.gameObject.CompareTag("Enemy")&& hasPowerUp)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 distFromPlayer = collision.gameObject.transform.position-transform.position;

            enemyRb.AddForce(distFromPlayer * powerUpStrength, ForceMode.Impulse);
        }
    }

}
