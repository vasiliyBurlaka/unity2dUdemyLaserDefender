﻿using System.Collections;
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

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
            Destroy(gameObject);
        }
    }

}
