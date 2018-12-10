using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{

    [Header("Effects")]
    [SerializeField] AudioClip deathSFX;
    [SerializeField] [Range(0, 1)] float deathSFXVolume = 0.7f;
    [SerializeField] GameObject deathVFX;
    [SerializeField] float deathVFXDuration = 1f;

    public void playFXAndDestroy()
    {

        //hide sprite and destroy children immediately upon effect activation
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        foreach (Transform child in gameObject.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        if (deathSFX)
            AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, deathSFXVolume);

        if (deathVFX)
        {
            GameObject effect = Instantiate(deathVFX, transform.position, transform.rotation);
            Destroy(effect, deathVFXDuration);

        }

        //destroy object after all effects have finished playing
        if (deathSFX && deathSFX.length >= deathVFXDuration)
        {
            Destroy(gameObject, deathSFX.length);
        }
        else
        {
            Destroy(gameObject, deathVFXDuration);
        }
    }


    public void MarkForDeath()
    {
        playFXAndDestroy();

        var player = gameObject.GetComponent<Player>();
        if(player)
            FindObjectOfType<Level>().LoadGameOver();
    }

}
