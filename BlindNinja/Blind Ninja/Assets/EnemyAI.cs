using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Grid grid;
    public bool northBordered;
    public bool southBordered;
    public bool eastBordered;
    public bool westBordered;

    // Start is called before the first frame update
    void Awake()
    {
        grid = FindObjectOfType<Grid>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            Move();
        }
    }

    void Move()
    {
        int r = Random.Range(0, 3);

        if(r == 0)
        {
            if(!northBordered)
            {
                Vector3 pos = gameObject.transform.position;
                gameObject.transform.position = grid.GetNearestPointOnGrid(pos + new Vector3(0, 0, -2));
            }
            else
            {
               
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

            }
        }

    }
}
