using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public GameObject player;
    public List<GameObject> enemies;
    public bool attackerChosen;

    private float pacemaker;
    private bool activatePacemaker;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("StartTurn", 0, 5);
        //StartCoroutine(StartTurn());
        InvokeRepeating("EndTurn", 0, 4.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(activatePacemaker)
        {
            pacemaker += Time.deltaTime;
        }
        
        if(!activatePacemaker)
        {
            pacemaker = 0;
        }
        
    }

    public void StartTurn()
    {
        StartCoroutine(EnemyHeartbeats());


        for(int i = 0; 0 < enemies.Count; i++)
        {
            Debug.Log(i);

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
        StopCoroutine(EnemyHeartbeats());
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

    void TriggerHeartbeat(int enemyIndex)
    {
        enemies[enemyIndex].GetComponent<EnemyHealth>().Heartbeat();
    }

    IEnumerator EnemyHeartbeats()
    {
        for (int o = 0; o < enemies.Count; o++)
        {
            TriggerHeartbeat(o);
            yield return new WaitForSeconds(1f);

        }
    }

}
