using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Inventory inventory;
    public static Player Instance;

    public Transform itemPlaceHolder;

    public bool isHoldItem = false;

    //public int Health;
    //public int Exp;

    //public Text HealthText;
    //public Text ExpText;

    private void Awake()
    {
        inventory = new Inventory(9);
        Instance = this;
    }

    /*
    public void IncreaseHealth(int value)
    {
        Health += value;
        HealthText.text = $"HP:{Health}";
    }

    public void IncreaseExp(int value)
    {
        Exp += value;
        ExpText.text = $"Exp:{Exp}";
    }
    */
    public void DropItem(Item item)
    {
        Vector3 spawnLocation = transform.position;

        Random.InitState((int)Time.time);
        Vector3 spawnOffset = new Vector3(spawnLocation.x + Random.Range(1f, 3f), spawnLocation.y - 0.9f, spawnLocation.z + Random.Range(1f, 3f));

        Item droppedItem = Instantiate(item, spawnOffset, Quaternion.identity);

        //droppedItem.rb.AddForce(spawnOffset * 0.5f, ForceMode.Impulse);//////TROCAR RIGIDBODY DO ITEM P 3d
    }
    public void DropCraftedItem()
    {
        isHoldItem = false;
    }
}
