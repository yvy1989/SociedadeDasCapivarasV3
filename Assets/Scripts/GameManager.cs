using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Player player;

    public ItemManager itemManager;

    private void Awake()
    {
        if(instance !=null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);

        itemManager = GetComponent<ItemManager>();
    }
    public SoundAudioClip[] soundAudioClips;
    [System.Serializable]
    public class SoundAudioClip
    {
        public SoudManager.SoudType sound;
        public AudioClip audioClip;
    }
}
