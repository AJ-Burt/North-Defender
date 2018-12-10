using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoShooter : MonoBehaviour {

    [Header("Game Logic")]
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] GameObject projectile;
    [SerializeField] float projectileSpeed = 10f;


    [Header("SFX")]
    [SerializeField] AudioClip shootSFX;
    [SerializeField] [Range(0, 1)] float shootSoundVolume = 0.25f;



    private float shotCounter;

    // Use this for initialization
    void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    // Update is called once per frame
    void Update()
    {
        CountDownAndShoot();
    }

    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f)
        {
            Fire();
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }


    private void Fire()
    {
        var deltaSpeed = projectileSpeed * Time.fixedDeltaTime;
        GameObject newProjectile = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
        newProjectile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -deltaSpeed);

        if(shootSFX)
        {
            AudioSource.PlayClipAtPoint(shootSFX, Camera.main.transform.position, shootSoundVolume);
        }

    }


}
