using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderTrigger : MonoBehaviour
{
    public enum Border {North, South, East, West }
    public Border myBorder;

    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        

        if (other.name == "Player")
        {
            if (myBorder == Border.North)
            {
                other.gameObject.GetComponent<PlayerMovement>().northBordered = true;
            }
            else if (myBorder == Border.South)
            {
                other.gameObject.GetComponent<PlayerMovement>().southBordered = true;
            }
            else if (myBorder == Border.East)
            {
                other.gameObject.GetComponent<PlayerMovement>().eastBordered = true;
            }
            else if (myBorder == Border.West)
            {
                other.gameObject.GetComponent<PlayerMovement>().westBordered = true;
            }
        }


        if (other.name == "Enemy")
        {
            if(myBorder == Border.North)
            {
                //other.gameObject.GetComponent<>().BorderNorth = true;
            }
            else if(myBorder == Border.South)
            {

            }
            else if(myBorder == Border.East)
            {

            }
            else if(myBorder == Border.West)
            {

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            if (myBorder == Border.North)
            {
                other.gameObject.GetComponent<PlayerMovement>().northBordered = false;
            }
            else if (myBorder == Border.South)
            {
                other.gameObject.GetComponent<PlayerMovement>().southBordered = false;
            }
            else if (myBorder == Border.East)
            {
                other.gameObject.GetComponent<PlayerMovement>().eastBordered = false;
            }
            else if (myBorder == Border.West)
            {
                other.gameObject.GetComponent<PlayerMovement>().westBordered = false;
            }
        }

        if (other.name == "Enemy")
        {
           
        }
    }

}
