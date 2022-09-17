using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioReverb : MonoBehaviour
{

    Rigidbody2D caveBox;

    // Reverb busses
    FMOD.Studio.Bus revPlate;
    FMOD.Studio.Bus revHall;
    FMOD.Studio.Bus revCave;

    // stores the original type of reverb for the level
    // reset at every load
    string stageMainRevType;

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

        // logic to set stageMainRevType
        /*
        switch (level_index)
        {
        case 1:
            stageMainRevType = "Plate";
            revPlate.setVolume (1);
            break;
        case 2:
            stageMainRevType = "Plate";
            revPlate.setVolume (1);
            break;
        case 3:
            stageMainRevType = "Plate";
            revPlate.setVolume (1);
            break;   
        case 4:
            stageMainRevType = "Cave";
            revCave.setVolume (1);
            break;
        }
        */

        // TEMP
        stageMainRevType = "Plate";
        revPlate.setVolume (1);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Cowboy")
        {
            Debug.Log("Player enters Cave");
            revCave.setVolume (1);
            revHall.setVolume (0);
            revPlate.setVolume (0);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Cowboy")
        {
            Debug.Log("Player exits Cave");
            revCave.setVolume (0);
            revHall.setVolume (0);
            revPlate.setVolume (1);
        }
    }
}
