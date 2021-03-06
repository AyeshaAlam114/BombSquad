using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : CharacterController
{
    public float moveSpeed;
    Rigidbody enemyRb;
    GameObject playerRb;


    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        playerRb =GameObject.FindGameObjectWithTag("Player");
        SetCharacter(this);
        SetHealth(10);
        InvokeRepeating("AttackByBomb", 1f, 10f);
       // StartCoroutine(AttackGap());
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        Vector3 moveDirection = (playerRb.transform.position - transform.position).normalized;
        enemyRb.AddForce(moveDirection* moveSpeed * Time.deltaTime);
    }

    public override void AttackByBomb()
    {
        
            GetBomb();
            Invoke(nameof(FireBomb),1f);
    }

    //IEnumerator AttackGap()
    //{
    //    yield return new WaitForSeconds(5);
    //    AttackByBomb();
    //}
}
