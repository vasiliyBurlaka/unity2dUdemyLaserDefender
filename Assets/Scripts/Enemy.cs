using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D colider)
    {
        DamageDiller damageDiller = colider.GetComponent<DamageDiller>();
        ProcessHit(damageDiller);
    }

    private void ProcessHit(DamageDiller damageDiller)
    {
        health -= damageDiller.GetDamage();
        if (health <= 0) {
            Destroy(gameObject);
        }
    }

}
