using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int health;

    // Start is called before the first frame update
    void Start()
    {
        if(health == 0)
        {
            health = 100;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        

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
        
        Invoke("KillMyself", 3);
    }

    private void KillMyself()
    {
        Destroy(gameObject);
    }
}
