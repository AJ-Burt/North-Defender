using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healable : MonoBehaviour {

    Damageable health;

    int startingHealth;
    
    void Start()
    {
        health = gameObject.GetComponent<Damageable>();
        startingHealth = health.GetHealth();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        HealPotion healPotion = other.gameObject.GetComponent<HealPotion>();
        if (healPotion)
        {
            ProcessHeal(healPotion);
        }

    }

    private void ProcessHeal(HealPotion healPotion)
    {
        var targetHealth = health.GetHealth() + healPotion.GetHealValue();

        if (targetHealth >= startingHealth)
            targetHealth = startingHealth;

        health.SetHealth(targetHealth);

        healPotion.GetComponent<Destroyable>().playFXAndDestroy();
    }
}
