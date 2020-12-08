using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;
    [SerializeField] float attackRange = 40f;
    [SerializeField] GameObject canon;


    // Update is called once per frame
    void Update()
    {
        FindEnemy();
    }

    private void FindEnemy()
    {
        if (targetEnemy)
        {
            FocusOnEnemy();
        }
        else
        {
            Shoot(false);
        }
    }

    private void FocusOnEnemy()
    {
        float distance = Vector3.Distance(gameObject.transform.position, targetEnemy.transform.position);
        if (distance <= attackRange)
        {
            objectToPan.LookAt(targetEnemy);
            Shoot(true); 
        }
        else
        {
            Shoot(false);
        }
    }

    private void Shoot(bool isActive)
    {
        var emissionModule = canon.GetComponent<ParticleSystem>().emission;
        emissionModule.enabled = isActive;
    }
}
