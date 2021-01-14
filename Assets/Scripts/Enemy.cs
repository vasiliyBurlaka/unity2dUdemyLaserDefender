using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health = 100;
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float projectileSpeed = 2f;
    [SerializeField] GameObject explosionParticle;
    [SerializeField] float explosionDuration = 2f;
    [SerializeField] AudioClip dieSound;
    [SerializeField] [Range(0, 1)] float dieSoundVolume = 0.7f;
    [SerializeField] List<AudioClip> fireSounds;
    [SerializeField] [Range(0, 1)] float fireSoundVolume = 0.2f;

    // Update is called once per frame
    void Update()
    {
        CountDownAndShoot();
    }

    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f) {
            Fire();
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void Fire()
    {
        AudioSource.PlayClipAtPoint(fireSounds[Random.Range(0, fireSounds.Count)], Camera.main.transform.position, fireSoundVolume);
        GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity);
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1 * projectileSpeed);
    }

    private void OnTriggerEnter2D(Collider2D colider)
    {
        DamageDiller damageDiller = colider.GetComponent<DamageDiller>();
        if (!damageDiller) { return ;}
        ProcessHit(damageDiller);
    }

    private void ProcessHit(DamageDiller damageDiller)
    {
        health -= damageDiller.GetDamage();
        damageDiller.Hit();
        if (health <= 0) {
            Die();
        }
    }

    private void Die()
    {
        GameObject explosion = Instantiate(explosionParticle, transform.position, transform.rotation);
        AudioSource.PlayClipAtPoint(dieSound, Camera.main.transform.position, dieSoundVolume);
        Destroy(gameObject);
        Destroy(explosion, explosionDuration);
    }
}
