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
        if((health + damage) > 0)
        {
            health -= damage;
        }
        else
        {
            gameObject.GetComponent<Rigidbody>().AddRelativeForce(500, 0, 0);
            Invoke("KillMyself", 3);
        }
        
    }

    private void KillMyself()
    {
        Destroy(gameObject);
    }

  
}
