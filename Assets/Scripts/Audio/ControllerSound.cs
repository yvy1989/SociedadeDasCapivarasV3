using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ControllerSound : MonoBehaviour
{
    public AudioSource music;
  public void Volume(float value){

    music.volume=value;
  }
  public void VolumeFX(float value){

    GameObject [] fxs =GameObject.FindGameObjectsWithTag("FX");
    for(int i=0; i<fxs.Length; i++){
        fxs[i].GetComponent<AudioSource>().volume=value;
    }
  }
}
