using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [Header("Stats")]
    [SerializeField] float health = 100;
    [SerializeField] int scoreValue = 150;
    [Header("Effects")]
    [SerializeField] GameObject deathVFX;
    [SerializeField] float deathVFXDuration = 1f;
    [SerializeField] List<AudioClip> deathSFX;
    [SerializeField] [Range(0,1)] float deathSoundVolume = 0.7f;
    [Header("Shield")]
    [SerializeField] GameObject shieldEffect;
    [SerializeField] float durationOfEffect = 1f;
    [SerializeField] AudioClip shieldSFX;
    [SerializeField] [Range(0, 1)] float shieldSoundVolume = 0.7f;
    [Header("Spawns")]
    [SerializeField] List<GameObject> availableSpawns;
    [SerializeField] float spawnChance = 0.9f;



    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        if (health <= 0)
        {
            Die();
        } else if(shieldEffect)
        {
            if(shieldSFX)
                AudioSource.PlayClipAtPoint(shieldSFX, Camera.main.transform.position, shieldSoundVolume);
            GameObject effect = Instantiate(shieldEffect, transform.position, transform.rotation);
            Destroy(effect, durationOfEffect);

        }
    }

    private void Die()
    {
        FindObjectOfType<GameSession>().AddToScore(scoreValue);

        Destroy(gameObject);

        PlayDeathFX();
        AttempSpawn();
    }

    private void AttempSpawn()
    {
        int availableSpawnCount = availableSpawns.Count;
        if (availableSpawnCount > 0)
        {

            var attemptSpawn = Random.Range(0, 1f);
            if (attemptSpawn <= spawnChance)
            {

                int randomSpawn = (int)Mathf.Floor(Random.Range(0, availableSpawnCount));
                Instantiate(availableSpawns[randomSpawn], transform.position, transform.rotation);
            }
        }
    }

    private void PlayDeathFX()
    {
        if (deathVFX)
        {
            GameObject explosion = Instantiate(deathVFX, transform.position, transform.rotation);
            Destroy(explosion, deathVFXDuration);
        }

        if (deathSFX.Count > 0)
        {
            int randomSound = (int)Mathf.Floor(Random.Range(0, deathSFX.Count));
            AudioSource.PlayClipAtPoint(deathSFX[randomSound], Camera.main.transform.position, deathSoundVolume);
        }
    }
}
