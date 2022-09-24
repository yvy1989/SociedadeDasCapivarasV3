using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[RequireComponent(typeof(Item))]
public class Collectable : MonoBehaviour
{
    public static event Action ItemCollected;


    private void OnTriggerEnter(Collider collision)
    {
        Player player = collision.GetComponent<Player>();

        if (player)
        {
            Item item = GetComponent<Item>();
            if (item != null)
            {
                player.inventory.Add(item);

                if (ItemCollected != null)
                {
                    ItemCollected();
                }


                Destroy(this.gameObject);
            }

        }
    }

}
