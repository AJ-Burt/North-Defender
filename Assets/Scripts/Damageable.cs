using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    [Header("Game Logic")]
    [SerializeField] int health = 200;

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (damageDealer)
        {
            ProcessHit(damageDealer);
        }

    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        if (health <= 0)
        {
            var destroyable = gameObject.GetComponent<Destroyable>();
            if(destroyable)
            {
                destroyable.MarkForDeath();
            }

        }
    }

    public int GetHealth()
    {
        return health;
    }

    public void SetHealth(int targetHealth)
    {
        health = targetHealth;
    }



}
