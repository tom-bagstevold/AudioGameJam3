using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerWallSources : MonoBehaviour
{
    public AudioSource[] sources;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerClips()
    {
        sources[0].Play();
        sources[1].PlayDelayed(0.5f);
        sources[2].PlayDelayed(1f);
        sources[3].PlayDelayed(1.5f);
    }

}
