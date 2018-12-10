using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuffDisplay : MonoBehaviour {

    TextMeshProUGUI buffText;
    Player player;

	// Use this for initialization
	void Start ()
    {
        buffText = GetComponent<TextMeshProUGUI>();
        player = FindObjectOfType<Player>();

    }
	
	// Update is called once per frame
	void Update () {
        buffText.text = player.GetCurrentBuffs();
	}
}
