using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioBrowsingManager : MonoBehaviour
{

    public AudioMixer masterMixer;

    [Header("Audio Mixer Group")]
    public AudioMixerGroup[] audioGroups;
    public float[] WetValues;

    [Header("Room Tone AudioSources")]
    public AudioSource[] roomToneSources;

    [Header("Ambience AudioSources")]
    public AudioSource[] ambienceToneSources;

    [Header("Specific Flavor AudioSources")]
    public AudioSource[] specificFlavorSources;

    [Header("Props AudioSources")]
    public AudioSource[] propsSources;

    [Header("Conversations AudioSources")]
    public AudioSource[] conversationSources;

    [Header("Current Selection")]
    public int currentMixerGroup;
    public int currentAudioSource;

    bool activated;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift) && !activated)
        {
            InitiateBrowsing(true);
            activated = true;
        }
        else if(Input.GetKeyDown(KeyCode.LeftShift) && activated)
        {
            InitiateBrowsing(false);
            activated = false;
            currentMixerGroup = 0;
        }

        if(Input.GetKeyDown(KeyCode.UpArrow) && activated)
        {
            if(currentMixerGroup >= 0 && currentMixerGroup < 4)
            {
                currentMixerGroup += 1;
                SelectGroup(currentMixerGroup);
            }
            else if(currentMixerGroup == 4)
            {
                currentMixerGroup = 1;
                SelectGroup(currentMixerGroup);
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && activated)
        {
            if (currentMixerGroup > 1 && currentMixerGroup <= 4)
            {
                currentMixerGroup -= 1;
                SelectGroup(currentMixerGroup);
            }
            else if (currentMixerGroup == 1)
            {
                currentMixerGroup = 4;
                SelectGroup(currentMixerGroup);
            }
        }



    }

    void InitiateBrowsing(bool isInitiated)
    {

        if(isInitiated)
        {
            masterMixer.SetFloat("RoomToneWet", 0f);
            masterMixer.SetFloat("AmbienceWet", 0f);
            masterMixer.SetFloat("SpecificFlavorsWet", 0f);
            masterMixer.SetFloat("PropsWet", 0f);
        }
        else
        {
            masterMixer.SetFloat("RoomToneWet", -80f);
            masterMixer.SetFloat("AmbienceWet", -80f);
            masterMixer.SetFloat("SpecificFlavorsWet", -80f);
            masterMixer.SetFloat("PropsWet", -80f);
        }

       

    }

    void SelectGroup(int groupSelected)
    {

        if (groupSelected == 1)
        {
            masterMixer.SetFloat("RoomToneWet", -80f);
            masterMixer.SetFloat("AmbienceWet", 0f);
            masterMixer.SetFloat("SpecificFlavorsWet", 0f);
            masterMixer.SetFloat("PropsWet", 0f);
        }

        if (groupSelected == 2)
        {
            masterMixer.SetFloat("AmbienceWet", -80f);
            masterMixer.SetFloat("RoomToneWet", 0f);
            masterMixer.SetFloat("SpecificFlavorsWet", 0f);
            masterMixer.SetFloat("PropsWet", 0f);
        }

        if (groupSelected == 3)
        {
            masterMixer.SetFloat("SpecificFlavorsWet", -80f);
            masterMixer.SetFloat("RoomToneWet", 0f);
            masterMixer.SetFloat("AmbienceWet", 0f);
            masterMixer.SetFloat("PropsWet", 0f);
        }

        if (groupSelected == 4)
        {
            masterMixer.SetFloat("PropsWet", -80f);
            masterMixer.SetFloat("RoomToneWet", 0f);
            masterMixer.SetFloat("AmbienceWet", 0f);
            masterMixer.SetFloat("SpecificFlavorsWet", 0f);
        }

    }

    void SelectClip()
    {
        
    }
}
