using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    public bool EnemyTriggered;
    public GameObject enemy;


    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Enemy")
        {
            EnemyTriggered = true;
            enemy = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Enemy")
        {
            EnemyTriggered = false;
            enemy = null;
        }
    }

}
