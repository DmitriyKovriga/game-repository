using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEngine : MonoBehaviour
{
    // Volume Bussses
    FMOD.Studio.Bus Master;
    FMOD.Studio.Bus Music;
    FMOD.Studio.Bus SFX;

    // Var for a level music event instance in FMOD
    // to start/stop music and change music with vars
    // 0-29 Intensity 1
    // 30-69 Intensity 2
    // 70-100 Intensity 3
    FMOD.Studio.EventInstance gameMusic;

    // to store banks volume
    [Range(0.0f, 1.0f)][SerializeField] private float masterVolume = 0.8f;
    [Range(0.0f, 1.0f)][SerializeField] private float musicVolume = 0.8f;
    [Range(0.0f, 1.0f)][SerializeField] private float sfxVolume = 0.8f;

    // Set var to store intensity
    [Range(0f, 100f)] public float newIntensity = 50;

    void Awake()
    {
        // Get Buses from FMOD (Can be found in FMOD -> Window/Mixer)
        Master = FMODUnity.RuntimeManager.GetBus("bus:/");
        Music = FMODUnity.RuntimeManager.GetBus("bus:/Music");
        SFX = FMODUnity.RuntimeManager.GetBus("bus:/SFX");
        
        // Get event by path, path can be found in Unity ->
        // FMOD/Event Browser/Events/Music/<name>/Full Path
        gameMusic = FMODUnity.RuntimeManager.CreateInstance("event:/Music/Biom_1_stage");
    }

    void Start()
    {
        gameMusic.start();
    }

    void Update()
    {
        Master.setVolume (masterVolume);
        Music.setVolume (musicVolume);
        SFX.setVolume (sfxVolume);

        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("intensity", newIntensity);
    }

}