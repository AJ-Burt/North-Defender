﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreDisplay : MonoBehaviour {
    
    TextMeshProUGUI scoreText;
    GameSession gameSession;

	// Use this for initialization
	void Start () {
        scoreText = GetComponent<TextMeshProUGUI>();
        gameSession = FindObjectOfType<GameSession>();
	}
	
	void Update () {
        try {

        scoreText.text = "Score: " + gameSession.GetScore().ToString();
        } 
        catch
        {
        
        }
	}
}