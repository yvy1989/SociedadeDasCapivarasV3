using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "Item Crafted", menuName = "Item Crafted", order = 51)]

public class CraftedItem : MonoBehaviour
{
    public string name;

    [System.Serializable]
    public class necessaryItens
    {
        public string itemName;
    }


    public List<necessaryItens> _necessaryItens = new List<necessaryItens>();
}
