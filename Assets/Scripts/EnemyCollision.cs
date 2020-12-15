using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{

    [SerializeField] GameObject deathFX;
    [SerializeField] int hits = 100;
    [SerializeField] ParticleSystem hitFX;
    [SerializeField] ParticleSystem hitSmoke;
    [SerializeField] Transform parent;

    // Start is called before the first frame update
    void Start()
    {

    }


    private void OnParticleCollision(GameObject other)
    {
        ProcessHits();
        ProcessHitParticles();
        if (hits < 1)
        {
            StartDeathSequence();
        }
    }

    private void ProcessHitParticles()
    {
        hitFX.Play();
        //if(hits < 50)
        //{
        //    hitSmoke.Play();
        //}
    }

    private void ProcessHits()
    {
        hits--;
      
    }

    private void StartDeathSequence()
    {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(fx, 1.5f);
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
