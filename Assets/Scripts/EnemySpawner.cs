using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update

    [Range(1f,10f)]
    [SerializeField] float secondsBetweenSpawns = 5f;
    [SerializeField] int numberOfEnemies = 5;
    [SerializeField] Transform parent;
    [SerializeField] AudioClip spawnSound;
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
        for (int i = 0; i < numberOfEnemies; i++)
        {
            EnemyCollision enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            GetComponent<AudioSource>().PlayOneShot(spawnSound);
            enemy.transform.parent = parent;
            yield return new WaitForSeconds(secondsBetweenSpawns);

        }
    }
}
