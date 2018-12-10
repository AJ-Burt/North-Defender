using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPotion : MonoBehaviour {

    [SerializeField] int healValue = 50;

    public int GetHealValue()
    {
        return healValue;
    }

}
