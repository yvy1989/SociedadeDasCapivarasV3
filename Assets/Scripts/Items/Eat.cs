using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eat : MonoBehaviour, IInteractable
{
    public string tipo;
    public void Interact()
    {
        Debug.Log("Comeu " + tipo);
        SoudManager.PlaySound(SoudManager.SoudType.EatApple);
    }
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
