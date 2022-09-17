using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioReverb : MonoBehaviour
{
    // Reverb busses
    FMOD.Studio.Bus revPlate;
    FMOD.Studio.Bus revHall;
    FMOD.Studio.Bus revCave;

    //
    float revCaveVolume;

    void Awake()
    {
        revPlate = FMODUnity.RuntimeManager.GetBus("bus:/Reverb Plate");
        revCave = FMODUnity.RuntimeManager.GetBus("bus:/Reverb Cave");
        revHall = FMODUnity.RuntimeManager.GetBus("bus:/Reverb Hall");
    }

    void Start()
    {
        // set all revs after load to 0 just in case
        revPlate.setVolume (0);
        revCave.setVolume (0);
        revHall.setVolume (0);
    }

    public void SetReverbCave()
    {
        Debug.Log("Cave rev set");
        revPlate.setVolume (0);
        revCave.setVolume (1);
        revHall.setVolume (0);
    }

    public void SetReverbPlate()
    {
        Debug.Log("Plate rev set");
        revPlate.setVolume (1);
        revCave.setVolume (0);
        revHall.setVolume (0);
    }
}