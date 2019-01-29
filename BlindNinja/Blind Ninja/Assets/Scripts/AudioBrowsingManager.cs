using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioBrowsingManager : MonoBehaviour
{

    public AudioMixer masterMixer;

    [Header("Audio Mixer Group")]
    public AudioMixerGroup selectedGroup;
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
    int previousAudioSource;

    bool activated;
    bool listeningSingleSources;
    int currentMixerGroupLength;


    // Start is called before the first frame update
    void Start()
    {
        currentMixerGroupLength = roomToneSources.Length - 1;
    }

    // Update is called once per frame
    void Update()
    {

        //Activation
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

            UnSelectCurrentClip();

            //roomToneSources[previousAudioSource].outputAudioMixerGroup = audioGroups[0];
            //ambienceToneSources[previousAudioSource].outputAudioMixerGroup = audioGroups[1];
            //specificFlavorSources[previousAudioSource].outputAudioMixerGroup = audioGroups[2];
            //propsSources[previousAudioSource].outputAudioMixerGroup = audioGroups[3];
            currentAudioSource = 0;
            previousAudioSource = 0;
        }

        //Browsing through layers

        if(Input.GetKeyDown(KeyCode.UpArrow) && activated)
        {
            if(currentMixerGroup >= 0 && currentMixerGroup < 4)
            {
                UnSelectCurrentClip();
                currentMixerGroup += 1;
                SelectGroup(currentMixerGroup);
            }
            else if(currentMixerGroup == 4)
            {
                UnSelectCurrentClip();
                currentMixerGroup = 1;
                SelectGroup(currentMixerGroup);
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && activated)
        {
            if (currentMixerGroup > 1 && currentMixerGroup <= 4)
            {
                UnSelectCurrentClip();
                currentMixerGroup -= 1;
                SelectGroup(currentMixerGroup);
            }
            else if (currentMixerGroup == 1)
            {
                UnSelectCurrentClip();
                currentMixerGroup = 4;
                SelectGroup(currentMixerGroup);
            }
        }

        //Browsing through sounds on layer

        if(Input.GetKeyDown(KeyCode.RightArrow) && activated)
        {
            

            if(currentAudioSource <= currentMixerGroupLength)
            {
                SelectClip(currentAudioSource);
                previousAudioSource = currentAudioSource;
                currentAudioSource += 1;
            }
            else if(currentAudioSource > currentMixerGroupLength)
            {
                currentAudioSource = 0;
                previousAudioSource = 0;
                SelectClip(currentAudioSource);
            }
            

        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && activated)
        {

            if (currentAudioSource <= currentMixerGroupLength)
            {
                SelectClip(currentAudioSource);
                previousAudioSource = currentAudioSource;
                currentAudioSource += 1;
            }
            else if (currentAudioSource > currentMixerGroupLength)
            {
                currentAudioSource = 0;
                previousAudioSource = 0;
                SelectClip(currentAudioSource);
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
            currentMixerGroupLength = roomToneSources.Length - 1;
        }

        if (groupSelected == 2)
        {
            masterMixer.SetFloat("AmbienceWet", -80f);
            masterMixer.SetFloat("RoomToneWet", 0f);
            masterMixer.SetFloat("SpecificFlavorsWet", 0f);
            masterMixer.SetFloat("PropsWet", 0f);
            currentMixerGroupLength = ambienceToneSources.Length - 1;
        }

        if (groupSelected == 3)
        {
            masterMixer.SetFloat("SpecificFlavorsWet", -80f);
            masterMixer.SetFloat("RoomToneWet", 0f);
            masterMixer.SetFloat("AmbienceWet", 0f);
            masterMixer.SetFloat("PropsWet", 0f);
            currentMixerGroupLength = specificFlavorSources.Length - 1;
        }

        if (groupSelected == 4)
        {
            masterMixer.SetFloat("PropsWet", -80f);
            masterMixer.SetFloat("RoomToneWet", 0f);
            masterMixer.SetFloat("AmbienceWet", 0f);
            masterMixer.SetFloat("SpecificFlavorsWet", 0f);
            currentMixerGroupLength = propsSources.Length - 1;
        }

    }

    void SelectClip(int sourceNum)
    {
        if(currentMixerGroup == 1)
        {
            masterMixer.SetFloat("RoomToneWet", 0f);
            roomToneSources[previousAudioSource].outputAudioMixerGroup = audioGroups[0];
            roomToneSources[currentAudioSource].outputAudioMixerGroup = selectedGroup;
            
        }

        else if (currentMixerGroup == 2)
        {
            masterMixer.SetFloat("AmbienceWet", 0f);
            ambienceToneSources[previousAudioSource].outputAudioMixerGroup = audioGroups[1];
            ambienceToneSources[currentAudioSource].outputAudioMixerGroup = selectedGroup;
            
        }

        else if (currentMixerGroup == 3)
        {
            masterMixer.SetFloat("SpecificFlavorsWet", 0f);
            specificFlavorSources[previousAudioSource].outputAudioMixerGroup = audioGroups[2];
            specificFlavorSources[currentAudioSource].outputAudioMixerGroup = selectedGroup;
            
        }

        else if (currentMixerGroup == 4)
        {
            masterMixer.SetFloat("PropsWet", 0f);
            propsSources[previousAudioSource].outputAudioMixerGroup = audioGroups[3];
            propsSources[currentAudioSource].outputAudioMixerGroup = selectedGroup;
            
        }

    }

    void UnSelectCurrentClip()
    {
        if (currentMixerGroup == 1)
        {
            masterMixer.SetFloat("RoomToneWet", 0f);
            roomToneSources[currentAudioSource].outputAudioMixerGroup = audioGroups[0];
            currentAudioSource = 0;

        }

        else if (currentMixerGroup == 2)
        {
            masterMixer.SetFloat("AmbienceWet", 0f);
            ambienceToneSources[currentAudioSource].outputAudioMixerGroup = audioGroups[1];
            currentAudioSource = 0;

        }

        else if (currentMixerGroup == 3)
        {
            masterMixer.SetFloat("SpecificFlavorsWet", 0f);
            specificFlavorSources[previousAudioSource].outputAudioMixerGroup = audioGroups[2];
            specificFlavorSources[currentAudioSource].outputAudioMixerGroup = audioGroups[2];
            currentAudioSource = 0;
        }

        else if (currentMixerGroup == 4)
        {
            masterMixer.SetFloat("PropsWet", 0f);
            propsSources[currentAudioSource].outputAudioMixerGroup = audioGroups[3];
            currentAudioSource = 0;
        }

    }
}
