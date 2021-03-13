using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] int health = 1;

    private void OnTriggerEnter2D(Collider2D colider)
    {
        DamageDiller damageDiller = colider.GetComponent<DamageDiller>();
        if (!damageDiller) { return ;}
        ProcessHit(damageDiller);
    }

    private void ProcessHit(DamageDiller damageDiller)
    {
        health -= damageDiller.GetDamage();
        if (health <= 0) {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
