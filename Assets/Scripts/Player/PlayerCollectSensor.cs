using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectSensor : MonoBehaviour
{

    public Material activeMat;
    public Color originColor;
    public Player player;

    private void Start()
    {
        player = GetComponentInParent<Player>();
        originColor = Color.white;
    }

    // Start is called before the first frame update
    private void OnTriggerStay(Collider other)
    {
        Item i;
        i = other.transform.GetComponent<Item>();
        if (i != null)
        {
            i.GetComponent<MeshRenderer>().material.color = activeMat.color;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Item i;
        i = other.transform.GetComponent<Item>();
        if (i != null)
        {
            i.GetComponent<MeshRenderer>().material.color = originColor;
        }
    }
}
