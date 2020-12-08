using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{

    [SerializeField] GameObject deathFX;
    [SerializeField] int hits = 100;

    // Start is called before the first frame update
    void Start()
    {
       
    }
    

    private void OnParticleCollision(GameObject other)
    {
        ProcessHits();
        if (hits < 1)
        {
            StartDeathSequence();
        }
    }

    private void ProcessHits()
    {
        hits--;
    }

    private void StartDeathSequence()
    {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
