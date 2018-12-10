using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour {

    WaveConfig waveConfig;
    Player player;

	// Use this for initialization
	void Start () {
        //waypoints = waveConfig.GetWaypoints();
        //transform.position = waypoints[waypointIndex].transform.position;
        
        transform.position = waveConfig.GetStartingPoint().position + new Vector3(
            0,
            Random.Range(0f, -2f),
            0
            );

        player = FindObjectOfType<Player>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Move();
    }

    public void SetWaveConfig(WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig;
    }

    private void Move()
    {
            if(player)
            {
                var targetPosition = player.transform.position;
                var movementThisFrame = waveConfig.GetMoveSpeed() * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementThisFrame);

            }
            
    }
}
