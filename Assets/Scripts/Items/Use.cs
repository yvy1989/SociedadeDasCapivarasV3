using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Use : MonoBehaviour, IInteractable
{
    public string tipo;
    public void Interact()
    {
        Debug.Log("Usou "+tipo);
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
