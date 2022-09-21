using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollision : MonoBehaviour
{
    ItemPickup i;
    private void OnTriggerExit(Collider other)
    {
        
        i = other.GetComponent<ItemPickup>();
        if (i != null)
        {
            other.GetComponent<MeshRenderer>().material.color = Color.white;
        }

    }

    private void OnTriggerStay(Collider other)
    {
        
        i = other.GetComponent<ItemPickup>();
        if (i != null)
        {
            other.GetComponent<MeshRenderer>().material.color = Color.green;
            
            if (Input.GetKey(KeyCode.E))
            {
                i.Pickup();
            }
        }
    }

    
}
