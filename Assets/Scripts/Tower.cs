using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;

    // Update is called once per frame
    void Update()
    {
        FocusOnEnemy();
    }

    private void FocusOnEnemy()
    {
        objectToPan.LookAt(targetEnemy);
    }
}
