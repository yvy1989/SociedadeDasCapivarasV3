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
        CollectItem
    
    }


    public static void PlaySound(SoudType sound)
    {
        GameObject soundGameObject = new GameObject("Sound");
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.PlayOneShot(GetAudioClip(sound));
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

