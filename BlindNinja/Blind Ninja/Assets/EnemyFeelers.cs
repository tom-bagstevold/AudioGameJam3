using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFeelers : MonoBehaviour
{
    GameObject parent;

    public enum FeelerDir {North, East, South, West}

    public FeelerDir myDir;

    private void Awake()
    {
        parent = gameObject.transform.parent.gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Enemy")
        {
            if(myDir == FeelerDir.North)
            {
                parent.GetComponent<EnemyAI>().northBordered = true;
            }
            if (myDir == FeelerDir.East)
            {
                parent.GetComponent<EnemyAI>().eastBordered = true;
            }
            if (myDir == FeelerDir.South)
            {
                parent.GetComponent<EnemyAI>().southBordered = true;
            }
            if (myDir == FeelerDir.West)
            {
                parent.GetComponent<EnemyAI>().westBordered = true;
            }
        }
        else if(other.name == "Player")
        {
            parent.GetComponent<EnemyAI>().playerInRange = true;

            if (myDir == FeelerDir.North)
            {
                parent.GetComponent<EnemyAI>().northBordered = true;
            }
            if (myDir == FeelerDir.East)
            {
                parent.GetComponent<EnemyAI>().eastBordered = true;
            }
            if (myDir == FeelerDir.South)
            {
                parent.GetComponent<EnemyAI>().southBordered = true;
            }
            if (myDir == FeelerDir.West)
            {
                parent.GetComponent<EnemyAI>().westBordered = true;
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Enemy")
        {
            if (myDir == FeelerDir.North)
            {
                parent.GetComponent<EnemyAI>().northBordered = false;
            }
            if (myDir == FeelerDir.East)
            {
                parent.GetComponent<EnemyAI>().eastBordered = false;
            }
            if (myDir == FeelerDir.South)
            {
                parent.GetComponent<EnemyAI>().southBordered = false;
            }
            if (myDir == FeelerDir.West)
            {
                parent.GetComponent<EnemyAI>().westBordered = false;
            }
        }
        else if (other.name == "Player")
        {
            parent.GetComponent<EnemyAI>().playerInRange = false;

            if (myDir == FeelerDir.North)
            {
                parent.GetComponent<EnemyAI>().northBordered = false;
            }
            if (myDir == FeelerDir.East)
            {
                parent.GetComponent<EnemyAI>().eastBordered = false;
            }
            if (myDir == FeelerDir.South)
            {
                parent.GetComponent<EnemyAI>().southBordered = false;
            }
            if (myDir == FeelerDir.West)
            {
                parent.GetComponent<EnemyAI>().westBordered = false;
            }
        }
    }
}
