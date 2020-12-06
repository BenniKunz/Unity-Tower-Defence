using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{

    [SerializeField] int scorePerHit = 1;
    [SerializeField] int hits = 50;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    

    private void OnParticleCollision(GameObject other)
    {
        hits--;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
