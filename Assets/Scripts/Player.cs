using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    float currentBuffDuration;
    string currentBuffs;

    FireOnInput playerFiring;

    private void Start()
    {
        playerFiring = gameObject.GetComponent<FireOnInput>();
        currentBuffs = "";

    }


        

    private void OnTriggerEnter2D(Collider2D other)
    {
        ProjectileUpgrade projectileUpgrade = other.gameObject.GetComponent<ProjectileUpgrade>();
        if (projectileUpgrade)
        {
            ProcessUpgrade(projectileUpgrade);
        }

    }


    private void ProcessUpgrade(ProjectileUpgrade projectileUpgrade)
    {
        var upgradeAmount = projectileUpgrade.GetUpgradeAmount();

        if (upgradeAmount <= playerFiring.GetProjectileCount() - 1)
        {
            currentBuffDuration = projectileUpgrade.GetUpgradeDuration();
            currentBuffs = projectileUpgrade.GetBuffText();
            StartCoroutine("RemoveProjectileBuff");
        }

        projectileUpgrade.GetComponent<Destroyable>().playFXAndDestroy();
    }

    IEnumerator RemoveProjectileBuff()
    {
        playerFiring.SetActiveProjectile(1);
        yield return new WaitForSeconds(currentBuffDuration);
        playerFiring.SetActiveProjectile(0);
        currentBuffs = "";
    }



    public string GetCurrentBuffs()
    {
        return currentBuffs;
    }

}
