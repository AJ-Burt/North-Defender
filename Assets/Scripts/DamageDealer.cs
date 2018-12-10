using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour {

    [Header("Game Logic")]
    [SerializeField] int damage = 100;
    [SerializeField] int collisionAffordance = 0;

    [Header("VFX")]
    [SerializeField] GameObject collisionVFX;
    [SerializeField] float collisionVFXDuration = 1f;

    [Header("SFX")]
    [SerializeField] AudioClip collisionSFX;
    [SerializeField] [Range(0, 1)] float collisionSFXVolume = 0.7f;

    public int GetDamage()
    {
        return damage;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (collisionAffordance == 0)
        {
            Destroy(gameObject);
        }
        else
        {
            collisionAffordance--;
        }
        PlayCollisionFX(other);
    }

    private void PlayCollisionFX(Collider2D other)
    {
        if (other.tag != "DisableFX" && collisionVFX)
        {
            GameObject newEffect = Instantiate(collisionVFX, transform.position, transform.rotation);
            Destroy(newEffect, collisionVFXDuration);
        }
        if (other.tag != "DisableFX" && collisionSFX)
        {
            AudioSource.PlayClipAtPoint(collisionSFX, Camera.main.transform.position, collisionSFXVolume);
        }
    }
}
