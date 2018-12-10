using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireOnInput : MonoBehaviour {

    [Header("Projectile")]
    [SerializeField] List<GameObject> projectilePrefabs;
    [SerializeField] float projectileSpeed = 1200f;
    [SerializeField] float projectileFiringPeriod = 0.4f;

    [SerializeField] AudioClip shootSFX;
    [SerializeField] [Range(0, 1)] float shootSoundVolume = 0.25f;

    Coroutine firingCouroutine;

    GameObject activeProjectile;

    // Use this for initialization
    void Start()
    {
        activeProjectile = projectilePrefabs[0];
    }

    public int GetProjectileCount()
    {
        return projectilePrefabs.Count;
    }

    public void SetActiveProjectile(int index)
    {
        activeProjectile = projectilePrefabs[index];
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }


    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            firingCouroutine = StartCoroutine(FireContiuously());
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(firingCouroutine);
        }
    }

    IEnumerator FireContiuously()
    {
        while (true)
        {
            var deltaSpeed = projectileSpeed * Time.fixedDeltaTime;
            GameObject laser = Instantiate(activeProjectile, transform.position, Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, deltaSpeed);

            if(shootSFX)
                AudioSource.PlayClipAtPoint(shootSFX, Camera.main.transform.position, shootSoundVolume);

            yield return new WaitForSeconds(projectileFiringPeriod);
        }
    }
}
