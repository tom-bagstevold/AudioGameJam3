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
    public GameObject player;

    private int actionRoll;

    [Header("Movement")]
    public Grid grid;
    public bool northBordered;
    public bool southBordered;
    public bool eastBordered;
    public bool westBordered;

    [Header("Audio")]
    public AudioSource movementSource;
    public AudioClip[] footsteps;

    private int clipNum;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.Find("Player");
        courage = 50;
        damage = 10;
        grid = FindObjectOfType<Grid>();

    }

    // Update is called once per frame
    void Update()
    {
        movementSource.clip = footsteps[clipNum];
        movementSource.Play();

        if (Input.GetKeyDown(KeyCode.K))
        {
            Move();
            
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            Attack();
        }

    }

    public void ModifyCouragePositive(int courageModifier)
    {
        courage += courageModifier;

        if(courage > 100)
        {
            courage = 100;
        }
        
    }

    public void ModifyCourageNegative(int courageModifier)
    {
        courage -= courageModifier;

        if (courage < 0)
        {
            courage = 0;
        }
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
        player.GetComponent<PlayerHealth>().TakeDamage(damage);

        attacking = false;
    }

    public void Move()
    {
        clipNum = Random.Range(0, footsteps.Length);



        int r = Random.Range(0, 4);

        if(r == 0)
        {
            if(!northBordered)
            {

                Vector3 pos = gameObject.transform.position;
                gameObject.transform.position = grid.GetNearestPointOnGrid(pos + new Vector3(0, 0, -2));
                movementSource.clip = footsteps[clipNum];
                movementSource.Play();
                
            }
            else
            {
                Move();
                movementSource.clip = footsteps[clipNum];
                movementSource.Play();
            }

        }
        else if(r == 1)
        {
            if (!southBordered)
            {
                Vector3 pos = gameObject.transform.position;
                gameObject.transform.position = grid.GetNearestPointOnGrid(pos + new Vector3(0, 0, 2));
                movementSource.clip = footsteps[clipNum];
                movementSource.Play();
            }
            else
            {
                Move();
                movementSource.clip = footsteps[clipNum];
                movementSource.Play();
            }
        }
        else if(r == 2)
        {
            if (!eastBordered)
            {
                Vector3 pos = gameObject.transform.position;
                gameObject.transform.position = grid.GetNearestPointOnGrid(pos + new Vector3(-2, 0, 0));
                movementSource.clip = footsteps[clipNum];
                movementSource.Play();
            }
            else
            {
                Move();
                movementSource.clip = footsteps[clipNum];
                movementSource.Play();
            }
        }
        else if(r == 3)
        {
            if (!westBordered)
            {
                Vector3 pos = gameObject.transform.position;
                gameObject.transform.position = grid.GetNearestPointOnGrid(pos + new Vector3(2, 0, 0));
                movementSource.clip = footsteps[clipNum];
                movementSource.Play();
            }
            else
            {
                Move();
                movementSource.clip = footsteps[clipNum];
                movementSource.Play();
            }
        }

    }

    public void CancelAttack()
    {
        Debug.Log("Attack Countered!");
        CancelInvoke("WindupTwo");
        CancelInvoke("AttackLanded");
    }
}
