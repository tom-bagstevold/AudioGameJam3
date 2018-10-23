using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Grid grid;

    public GameObject[] directions;

    public bool northBordered;
    public bool southBordered;
    public bool eastBordered;
    public bool westBordered;

    private bool attackNorth;
    private bool attackSouth;
    private bool attackEast;
    private bool attackWest;

    void Awake()
    {
    grid = FindObjectOfType<Grid>();
    }

    // Update is called once per frame
    void Update()
    {
        if(directions[0].GetComponent<EnemyTrigger>().EnemyTriggered)
        {
            attackNorth = true;
        }
        if (directions[1].GetComponent<EnemyTrigger>().EnemyTriggered)
        {
            attackSouth = true;
        }
        if (directions[2].GetComponent<EnemyTrigger>().EnemyTriggered)
        {
            attackEast = true;
        }
        if (directions[3].GetComponent<EnemyTrigger>().EnemyTriggered)
        {
            attackWest = true;
        }


        if (!directions[0].GetComponent<EnemyTrigger>().EnemyTriggered)
        {
            attackNorth = false;
        }
        if (!directions[1].GetComponent<EnemyTrigger>().EnemyTriggered)
        {
            attackSouth = false;
        }
        if (!directions[2].GetComponent<EnemyTrigger>().EnemyTriggered)
        {
            attackEast = false;
        }
        if (!directions[3].GetComponent<EnemyTrigger>().EnemyTriggered)
        {
            attackWest = false;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if(!attackWest && !westBordered)
            {
                Vector3 pos = gameObject.transform.position;
                gameObject.transform.position = grid.GetNearestPointOnGrid(pos + new Vector3(2, 0, 0));
            }
            else if(attackWest)
            {
                directions[3].GetComponent<EnemyTrigger>().enemy.GetComponent<EnemyHealth>().TakeDamage(10);
            }

            
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if(!attackEast && !eastBordered)
            {
                Vector3 pos = gameObject.transform.position;
                gameObject.transform.position = grid.GetNearestPointOnGrid(pos + new Vector3(-2, 0, 0));
            }
            else if(attackEast)
            {
                directions[2].GetComponent<EnemyTrigger>().enemy.GetComponent<EnemyHealth>().TakeDamage(10);
            }
            
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            if(!attackNorth && !northBordered)
            {
                Vector3 pos = gameObject.transform.position;
                gameObject.transform.position = grid.GetNearestPointOnGrid(pos + new Vector3(0, 0, -2));
            }
            else if(attackNorth)
            {
                directions[0].GetComponent<EnemyTrigger>().enemy.GetComponent<EnemyHealth>().TakeDamage(10);
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if(!attackSouth && !southBordered)
            {
                Vector3 pos = gameObject.transform.position;
                gameObject.transform.position = grid.GetNearestPointOnGrid(pos + new Vector3(0, 0, 2));
            }
            else if(attackNorth)
            {
                directions[1].GetComponent<EnemyTrigger>().enemy.GetComponent<EnemyHealth>().TakeDamage(10);
            }
           
        }


    }
}
