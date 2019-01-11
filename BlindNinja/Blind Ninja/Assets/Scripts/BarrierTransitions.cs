using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BarrierTransitions : MonoBehaviour
{
    public enum TransitionType { HighToLow, LowToHigh, Across };
    public TransitionType transition;

    public Transform start;
    public Transform end;

    public GameObject player;
    public bool activated;
    public float speed;

    public bool transitionInProgress;

    private Vector3 pos;
    private Vector3 startPos;
    
    private float startTime;
    private float journeyLength;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player_Exploration");

        startPos = start.position;

        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        /*
        
        if(transitionInProgress)
        {
            float step = speed * Time.deltaTime;
            player.transform.position = Vector3.MoveTowards(pos, startPos, step);
        }
        
        */


    }

    /*private void LateUpdate()
    {

        if (transitionInProgress)
        {
            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLength;

            player.transform.position = Vector3.Lerp(pos, startPos, fracJourney);

            Debug.Log(fracJourney);

            if (fracJourney >= 1)
            {
                transitionInProgress = false;
                //player.GetComponent<CharacterController>().enabled = true;
            }
        }
        
    }*/


    private void OnTriggerEnter(Collider other)
    {
        //player.GetComponent<PlayMakerFSM>().enabled = false;
        //player.GetComponent<CharacterController>().enabled = false;
    }

    private void OnTriggerExit(Collider other)
    {
        
        /*
        pos = player.transform.position;
        transitionInProgress = true;
        

        /*

        Debug.Log("Exiting...");
        pos = player.transform.position;
        startTime = Time.time;
        journeyLength = Vector3.Distance(pos, startPos);
        Debug.Log("PlayerPos is " + player.transform.position);
        //player.GetComponent<CharacterController>().enabled = false;
        transitionInProgress = true;
            */
           
    }
}
