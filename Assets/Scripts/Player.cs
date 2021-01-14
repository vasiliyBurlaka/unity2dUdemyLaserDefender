using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //configuration paprams
    [Header("Player")]
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 1f;
    [SerializeField] float health = 300f;

    [Header("Projectile")]
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileFiringPeriod = 0.1f;
    [SerializeField] GameObject explosionParticle;
    [SerializeField] float explosionDuration = 2f;
    
    Vector3 minPos;
    Vector3 maxPos;
    Coroutine fireCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoundaries();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
    }

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            fireCoroutine = StartCoroutine(FireContinuously());
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(fireCoroutine);
        }
    }

    IEnumerator FireContinuously()
    {
        while(true) {
            GameObject laser = Instantiate(
                laserPrefab, 
                transform.position, 
                Quaternion.identity
            ) as GameObject;

            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);

            yield return new WaitForSeconds(projectileFiringPeriod);
        }
    }

    private void Move()
    {
        float deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        float newXPos = Mathf.Clamp(transform.position.x + deltaX, minPos.x, maxPos.x);
        float newYPos = Mathf.Clamp(transform.position.y + deltaY, minPos.y, maxPos.y);

        transform.position = new Vector2(newXPos, newYPos);
    }

    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        minPos = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)) + new Vector3(padding, padding, 0);
        maxPos = gameCamera.ViewportToWorldPoint(new Vector3(1, 1, 0)) - new Vector3(padding, padding, 0);
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
        Destroy(gameObject);
        Destroy(explosion, explosionDuration);
    }

}
