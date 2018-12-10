using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    [CreateAssetMenu(menuName = "Enemy Wave Config")]

public class WaveConfig : ScriptableObject {

    [SerializeField] List<GameObject> enemyPrefab;
    [SerializeField] List<GameObject> startingPoints;
    [SerializeField] float timeBetweenSpawns = 0.5f;
    [SerializeField] int numberOfEnemies = 5;
    [SerializeField] float moveSpeed = 2f;

    public GameObject GetEnemyPrefab() {
        int randomEnemy = (int)Mathf.Floor(Random.Range(0, enemyPrefab.Count));
        return enemyPrefab[randomEnemy];
    }

    public Transform GetStartingPoint()
    {
        int randomStartingPoint = (int)Mathf.Floor(Random.Range(0, startingPoints.Count));
        return startingPoints[randomStartingPoint].transform;
    }

    public float GetTimeBetweenSpawns() { return timeBetweenSpawns; }

    public int GetNumberOfEnemies() { return numberOfEnemies;  }

    public float GetMoveSpeed() { return moveSpeed;  }


}
