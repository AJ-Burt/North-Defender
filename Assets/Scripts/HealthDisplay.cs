using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthDisplay : MonoBehaviour {

    TextMeshProUGUI healthText;
    Player player;
    string startingHealth;

    // Use this for initialization
    void Start()
    {
        healthText = GetComponent<TextMeshProUGUI>();
        player = FindObjectOfType<Player>();
        startingHealth = player.GetComponent<Damageable>().GetHealth().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(player)
            healthText.text = "Health: " + player.GetComponent<Damageable>().GetHealth().ToString() + "/" + startingHealth;
    }
}
