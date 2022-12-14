using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItems : MonoBehaviour
{
    public Transform spawnLoc;
    public Item spawnedItem;
    public Item[] spawnedItems;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpanwItem()
    {
        /*
        for (int i = 0; i < 3; i++)
        {
            Item _spawnedItem = Instantiate(spawnedItem, new Vector3(transform.position.x + Random.Range(0,4), 
                                                                     transform.position.y+0.2f, 
                                                                     transform.position.z + Random.Range(0, 4)), Quaternion.identity);

        }*/

        foreach (var item in spawnedItems)
        {
            Item _spawnedItem = Instantiate(item, new Vector3(spawnLoc.position.x + Random.Range(0.5f, 1.4f),
                                                                     spawnLoc.position.y,
                                                                     spawnLoc.position.z + Random.Range(0.4f, 2.8f)), Quaternion.identity);
        }
    }
}
