using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    [SerializeField] GameObject currentPlayer;

    public void SetPlayer(GameObject player)
    {
        currentPlayer = player;
    }

    private void SetUpSingleton()
    {
        int numberGameSessions = FindObjectsOfType<PlayerManager>().Length;
        if (numberGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }


}
