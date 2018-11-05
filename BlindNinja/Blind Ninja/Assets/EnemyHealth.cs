using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public int health;
    public bool markForDestruction;
    public GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");

        if(health == 0)
        {
            health = 50;
        }
    }

    public void TakeDamage(int damage)
    {
        gameObject.GetComponent<EnemyAI>().hasBeenHit = true;
        gameObject.GetComponent<EnemyAI>().CancelAttack();

        if ((health + damage) > 0)
        {
            health -= damage;
        }
        else
        {
            gameObject.GetComponent<Rigidbody>().AddRelativeForce(500, 500, 0);
            MarkForDestruction();
        }
        
    }

    private void MarkForDestruction()
    {
        markForDestruction = true;
        gameManager.GetComponent<TurnManager>().RemoveEnemyFromList();
        Invoke("KillMyself", 3);
    }

    private void KillMyself()
    {
        Destroy(gameObject);
    }

    public void Heartbeat()
    {
        //Trigger AudioSource Here, playing the right track based on the health value of the enemy 

    }

  
}
