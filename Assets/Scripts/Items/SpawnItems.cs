using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItems : MonoBehaviour
{

    public Item spawnedItem;


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
        for (int i = 0; i < 3; i++)
        {
            Item _spawnedItem = Instantiate(spawnedItem, new Vector3(transform.position.x + Random.Range(0,4), 
                                                                     transform.position.y+0.2f, 
                                                                     transform.position.z + Random.Range(0, 4)), Quaternion.identity);

        }
    }
}
