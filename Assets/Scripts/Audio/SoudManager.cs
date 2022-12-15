using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoudManager
{
    public enum SoudType 
    { 
        PlayerMove,
        JaguarAttack,
        Damage,
        CollectItem,
        EatApple,
        Craft
    }
    private static Dictionary<SoudType, float> soundTimeDictionary;
   
    public static void Initialize()
    {
        soundTimeDictionary = new Dictionary<SoudType, float>();
        soundTimeDictionary[SoudType.PlayerMove] = 0f;
      
    }
    public static void PlaySound(SoudType sound)
    {  
        if (CanPlaySound(sound))
        {
            GameObject soundGameObject = new GameObject("Sound");
            AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
       
            if(sound==SoudManager.SoudType.PlayerMove){
                audioSource.volume=0.1f;
                audioSource.PlayOneShot(GetAudioClip(sound));
            }else{   
                  audioSource.PlayOneShot(GetAudioClip(sound));
            }
        }
    }
    private static bool CanPlaySound(SoudType sound)
    {
        switch (sound) 
        {
            default:
                return true;

            case SoudType.PlayerMove:
                if (soundTimeDictionary.ContainsKey(sound))
                {
                    float lastTimePlayed= soundTimeDictionary[sound];
                    float playerMoveTimerMax = 0.55f;
                    if(playerMoveTimerMax+ lastTimePlayed < Time.time)
                    {
                        soundTimeDictionary[sound] = Time.time;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }
        }

        

    }
    private static AudioClip GetAudioClip(SoudType sound)
    {
        foreach (GameManager.SoundAudioClip soundAudioClip in GameManager.instance.soundAudioClips)
        {
            if (soundAudioClip.sound == sound)
            {
                return soundAudioClip.audioClip;
            }
        }
        
        Debug.LogError("Sound " + sound + " Not Found!");

        return null;
    }
  
}

