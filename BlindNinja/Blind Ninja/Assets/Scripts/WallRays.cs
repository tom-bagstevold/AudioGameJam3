using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRays : MonoBehaviour
{
    public enum direction {left, right, forward, backward}
    public direction raycastDirection;
    public AudioSource source;

    public AudioClip wallClip;
    public AudioClip transitionClip;

    public Vector3 dir;
    //private LineRenderer myLine;

    // Start is called before the first frame update
    void Start()
    {
      //  myLine = GetComponent<LineRenderer>();

       

    }

    // Update is called once per frame
    void Update()
    {
        if (raycastDirection == direction.left)
        {
            dir = transform.right;
        }
        else if (raycastDirection == direction.right)
        {
            dir = transform.right;
        }
        else if (raycastDirection == direction.forward)
        {
            dir = transform.forward;
        }
        else if (raycastDirection == direction.backward)
        {
            dir = transform.forward;
        }

        RaycastHit rayray;
        Ray myRayray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward);

        if (Physics.Raycast(transform.position, dir, out rayray))
        {
            source.transform.position = rayray.point;

            Debug.Log("Collided with " + rayray.transform.name);

            //Debug.DrawRay(transform.position, dir);

           // myLine.SetPosition(0, transform.position);
           // myLine.SetPosition(1, rayray.point);

            if(rayray.transform.tag == "Wall")
            {

               source.clip = wallClip;
            }
            else if(rayray.transform.tag == "Transition")
            {
                source.clip = transitionClip;
            }
            
        }
            


    }
}
