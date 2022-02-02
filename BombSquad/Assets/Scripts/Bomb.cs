using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float timeToExplode;
    public int powerToDamage;
    public ParticleSystem explosionEffect;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ExplosionTimer());
        this.GetComponent<SphereCollider>().enabled = false;
        explosionEffect = transform.GetChild(0).GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Explosion()
    {
        this.GetComponent<SphereCollider>().enabled = true;
        this.GetComponent<MeshRenderer>().enabled = false;
        explosionEffect.gameObject.SetActive(true);
        explosionEffect.Play();
        this.GetComponent<Rigidbody>().AddExplosionForce(600, this.transform.position, 30);
        Invoke(nameof(DestroyBomb), 1f);
    }

    void DestroyBomb()
    {
        Destroy(gameObject);
    }
    void DoDamage(Collider hittedCharacter,int PowerToDamage)
    {
        hittedCharacter.GetComponent<CharacterController>().GetDamage(PowerToDamage);
    }

    IEnumerator ExplosionTimer()
    {
        yield return new WaitForSeconds(timeToExplode);
        Explosion();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Enemy"))
            DoDamage(other, powerToDamage);
    }

}
