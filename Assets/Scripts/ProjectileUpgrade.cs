using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileUpgrade : MonoBehaviour {

    [SerializeField] int upgradeAmount = 1;
    [SerializeField] float upgradeDuration = 10f;
    [SerializeField] string buffText;
    
    public int GetUpgradeAmount()
    {
        return upgradeAmount;
    }

    public float GetUpgradeDuration()
    {
        return upgradeDuration;
    }

    public string GetBuffText()
    {
        return buffText;
    }
}
