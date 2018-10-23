using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("Combat Variables")]
    public int courage;
    public int damage;
    public bool hasBeenHit;
    public bool playerInRange;
    public bool canAct;
    public bool canAttack;
    public bool attacking;

    private int actionRoll;

    [Header("Movement")]
    public Grid grid;
    public bool northBordered;
    public bool southBordered;
    public bool eastBordered;
    public bool westBordered;

    // Start is called before the first frame update
    void Awake()
    {
        courage = 50;
        damage = 10;
        grid = FindObjectOfType<Grid>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            Move();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            Attack();
        }

    }

    public void ModifyCourage(int courageModifier)
    {
        courage += courageModifier;
    }

    public void RollAction()
    {
        actionRoll = Random.Range(0, 100);

        if (actionRoll <= courage)
        {
            canAct = true;
        }
        else
        {
            canAct = false;
        }

    }

    public void TakeAction()
    {
        if (canAttack)
        {
            Attack();
        }
        else
        {
            Move();
        }
    }

    public void Attack()
    {
        attacking = true;

        //play wind up

        Invoke("WindupTwo", 0.6f);

    }

    void WindupTwo()
    {
        Invoke("AttackLanded", 0.6f);
    }

    void AttackLanded()
    {
        //Code for murdering player here

        attacking = false;
    }

    public void Move()
    {
        int r = Random.Range(0, 4);

        if(r == 0)
        {
            if(!northBordered)
            {
                Vector3 pos = gameObject.transform.position;
                gameObject.transform.position = grid.GetNearestPointOnGrid(pos + new Vector3(0, 0, -2));
            }
            else
            {
                Move();
            }

        }
        else if(r == 1)
        {
            if (!southBordered)
            {
                Vector3 pos = gameObject.transform.position;
                gameObject.transform.position = grid.GetNearestPointOnGrid(pos + new Vector3(0, 0, 2));
            }
            else
            {
                Move();
            }
        }
        else if(r == 2)
        {
            if (!eastBordered)
            {
                Vector3 pos = gameObject.transform.position;
                gameObject.transform.position = grid.GetNearestPointOnGrid(pos + new Vector3(-2, 0, 0));
            }
            else
            {
                Move();
            }
        }
        else if(r == 3)
        {
            if (!westBordered)
            {
                Vector3 pos = gameObject.transform.position;
                gameObject.transform.position = grid.GetNearestPointOnGrid(pos + new Vector3(2, 0, 0));
            }
            else
            {
                Move();
            }
        }

    }
}
