using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class NecessaryFeatures 
{    
    public string name;
    [TextArea(3, 10)]
    public List<Item> requiredItems = new List<Item>();
   
}






