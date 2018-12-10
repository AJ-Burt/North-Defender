using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowAccummulator : MonoBehaviour {

    [SerializeField] float emissionRateAccumulator = 0.01f;
    [SerializeField] float maxEmissionRate = 26f;

    ParticleSystem snow;

    private float currentEmisionRate;

    // Use this for initialization
    void Start () {

        snow = GetComponent<ParticleSystem>();
        currentEmisionRate = snow.emission.rateOverTimeMultiplier;

    }
	
	// Update is called once per frame
	void Update ()
    {
        //only increase if under max rate
        if(currentEmisionRate >= maxEmissionRate)
            return;
        
        var emission = snow.emission;
        var newEmissionRate = currentEmisionRate + emissionRateAccumulator * Time.deltaTime;

        emission.rateOverTimeMultiplier = newEmissionRate;
        currentEmisionRate = newEmissionRate;
    }
} 
