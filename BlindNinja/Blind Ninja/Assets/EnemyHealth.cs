using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public int health;

    // Start is called before the first frame update
    void Start()
    {


        if(health == 0)
        {
            health = 50;
        }
    }

    public void TakeDamage(int damage)
    {
        gameObject.GetComponent<EnemyAI>().hasBeenHit = true;

        if((health + damage) > 0)
        {
            health -= damage;
        }
        else
        {
            gameObject.GetComponent<Rigidbody>().AddRelativeForce(500, 500, 0);
            Invoke("KillMyself", 3);
        }
        
    }

    private void KillMyself()
    {
        Destroy(gameObject);
    }

  
}
