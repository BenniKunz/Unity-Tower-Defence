using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Transform objectToPan;
    [SerializeField] float attackRange = 40f;
    [SerializeField] GameObject canon;
    [SerializeField] Transform targetEnemy;

    // Update is called once per frame
    void Update()
    {
        SetTargetEnemy();
        FindEnemy();
    }

    private void SetTargetEnemy()
    {
        EnemyCollision[] targetEnemyArray = FindObjectsOfType<EnemyCollision>();
        if(targetEnemyArray.Length == 0) { return;  }
        Transform closestEnemy = targetEnemyArray[0].transform;

        foreach (EnemyCollision enemyCollision in targetEnemyArray)
        {
            closestEnemy = GetClosest(closestEnemy, enemyCollision.transform);
        }
        targetEnemy = closestEnemy.GetComponentInChildren<HelperScript>().transform;
    }

    private Transform GetClosest(Transform closestEnemy, Transform enemyCollision)
    {
        float currentDistance = Vector3.Distance(gameObject.transform.position, closestEnemy.position);
        float checkDistance = (Vector3.Distance(gameObject.transform.position, enemyCollision.position));
        
        if(currentDistance > checkDistance)
        {
            return enemyCollision;
        }    
            return closestEnemy;
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
