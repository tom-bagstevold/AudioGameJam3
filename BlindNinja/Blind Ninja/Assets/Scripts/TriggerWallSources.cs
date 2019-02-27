using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerWallSources : MonoBehaviour
{
    public AudioSource[] sources;
    public AudioClip chosenClip;

    private AudioSource chosenSource;
    public List<AudioSource> nonChosenSources;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            TriggerClips();
        }
    }

    public void TriggerClips2()
    {
        //Alternate way to trigger clips

        sources[0].Play();
        sources[1].PlayDelayed(0.3f);
        sources[2].PlayDelayed(0.6f);
        sources[3].PlayDelayed(0.9f);
    }

    public void TriggerClips()
    {
        if (nonChosenSources != null)
        {
            nonChosenSources.Clear();
        }


        for (int i = 0; i < sources.Length; i++)
        {
            if (sources[i].clip == chosenClip)
            {
                chosenSource = sources[i];
            }
            else
            {
                nonChosenSources.Add(sources[i]);
            }
        }

        chosenSource.Play();

        nonChosenSources[0].PlayDelayed(0.4f);
        nonChosenSources[1].PlayDelayed(0.8f);
        nonChosenSources[2].PlayDelayed(1.2f);
    }

}
