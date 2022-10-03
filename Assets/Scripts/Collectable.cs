using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[RequireComponent(typeof(Item))]
public class Collectable : MonoBehaviour
{
    public static event Action ItemCollected;


    private void OnTriggerStay(Collider collision)
    {
        PlayerCollectSensor playerSensor = collision.GetComponent<PlayerCollectSensor>();

        if (playerSensor && Input.GetKey(KeyCode.E))
        {
            Item item = GetComponent<Item>();
            if (item != null)
            {
                playerSensor.player.inventory.Add(item);

                if (ItemCollected != null)
                {
                    ItemCollected();
                }


                Destroy(this.gameObject);
            }

        }
    }

}
