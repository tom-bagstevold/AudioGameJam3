using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public GameObject player;
    public List<GameObject> enemies;
    public bool attackerChosen;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("StartTurn", 0, 5);
        InvokeRepeating("EndTurn", 0, 4.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartTurn()
    {
        //heartbeat shit here


        for(int i = 0; 0 < enemies.Count; i++)
        {
            if (!enemies[i].GetComponent<EnemyAI>().hasBeenHit)
            {
                enemies[i].GetComponent<EnemyAI>().ModifyCouragePositive(20);

            }
            else if(enemies[i].GetComponent<EnemyAI>().hasBeenHit)
            {
                enemies[i].GetComponent<EnemyAI>().ModifyCourageNegative(20);
                enemies[i].GetComponent<EnemyAI>().hasBeenHit = false;
            }

            enemies[i].GetComponent<EnemyAI>().RollAction();

            if(enemies[i].GetComponent<EnemyAI>().canAct)
            {
                if(enemies[i].GetComponent<EnemyAI>().playerInRange && !attackerChosen)
                {
                    enemies[i].GetComponent<EnemyAI>().Attack();
                    attackerChosen = true;

                    Debug.Log("Enemy " + i + " is attacking");

                }
                else
                {
                    enemies[i].GetComponent<EnemyAI>().Move();
                }
            }

        }

        
        
    }

     public void EndTurn()
    {
        attackerChosen = false;
    }

    public void RemoveEnemyFromList()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            if(enemies[i].GetComponent<EnemyHealth>().markForDestruction)
            {
                enemies.Remove(enemies[i]);
                
            }
        }
    }

}
