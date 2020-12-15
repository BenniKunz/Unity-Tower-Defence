using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int healthPoints = 3;
    [SerializeField] int healtDecrease = 1;
    [SerializeField] Text healthText;
    [SerializeField] Text EnemieCount;
    // Start is called before the first frame update
    void Start()
    {
        healthText.text = healthPoints.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyCollision[] enemies = FindObjectsOfType<EnemyCollision>();
        int numEnemies = enemies.Length;

        EnemieCount.text = numEnemies.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        healthPoints -= healtDecrease;
        healthText.text = healthPoints.ToString();
    }
}
