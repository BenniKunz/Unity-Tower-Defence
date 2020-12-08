using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] float secondsBetweenSpawns = 5f;
    public EnemyCollision enemyPrefab;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    //Update is called once per frame
    void Update()
    {
    }

    IEnumerator SpawnEnemy()
    {
        for (int i = 0; i < 10; i++)
        {
            EnemyCollision spawn = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(secondsBetweenSpawns);

        }

    }
}
