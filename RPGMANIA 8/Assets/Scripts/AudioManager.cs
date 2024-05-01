using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio; 

public class AudioManager : MonoBehaviour
{
    public EventReference MainMenuTheme, OverWorldTheme;
    private EventInstance soundInstance;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void PlaySound(string Theme)
    {
        
        PLAYBACK_STATE state;
        soundInstance.getPlaybackState(out state);
        if(state == PLAYBACK_STATE.PLAYING)
        {
            soundInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE); 
        }

        EventReference songToPlay; 

        switch (Theme)
        {
            case "Main Menu":
                songToPlay = MainMenuTheme;
                break;
            case "OverWorld":
            case "SampleScene":
                songToPlay = OverWorldTheme; 
                break;
            default:
                songToPlay = MainMenuTheme;
                break; 
        }

        soundInstance = RuntimeManager.CreateInstance(songToPlay);

        if (state != PLAYBACK_STATE.STOPPED || !IsEventPlaying(soundInstance))
            soundInstance.start();
    }

    bool IsEventPlaying(EventInstance instance)
    {
        PLAYBACK_STATE state;
        instance.getPlaybackState(out state);
        return state != PLAYBACK_STATE.STOPPED;
    }


    public void StopSound()
    {
        soundInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        soundInstance.release();
    }
}
