using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CraftManager : MonoBehaviour
{
    public int MergingIdSelected;

    //int[,,] bd = new int[1, 6, 2]{
    //            { { 1, 2}, { 3, 4} , { 3, 4}, { 1, 2}, { 3, 4} , { 3, 4}  }
    //        };


    public List<NecessaryFeatures> bd = new List<NecessaryFeatures>();
    
    void Start()
    {
        
    }

    void Update()
    {


    }
    public void CheckPossibilitToyMerging(int MergingId)
    {
        MergingIdSelected = MergingId;

        CheckIfContains();

    }


    
    void CheckIfContains()
    {

        ////foreach (var item in InventoryManager.Instance.Items)
        ////{

        ////}

    }


    private void OnTriggerEnter(Collider collider)
    {
        
    }


    private void OnTriggerStay(Collider collider)
    {
   
    }


    private void OnTriggerExit(Collider collider)
    {
      



    }


    //if (collider.gameObject.GetComponent<Item>())
    //{
    //    itemSelected = collider.gameObject.GetComponent<Item>();
    //}

    //if (itemSelected.GetHashCode() == 0)//Mapa
    //{

    //}
    //else if (itemSelected.GetHashCode() == 1)//Fogueira
    //{

    //}
    //else if (itemSelected.GetHashCode() == 2)//Abrigo
    //{

    //}
    //else if (itemSelected.GetHashCode() == 3)//Machado
    //{

    //}
    //else if (itemSelected.GetHashCode() == 4)//Mochila
    //{

    //}
    //else if (itemSelected.GetHashCode() == 5)//Ponte
    //{

    //}
    //else if (itemSelected.GetHashCode() == 6)//frutaVenenosa
    //{

    //}
    //else if (itemSelected.GetHashCode() == 7)//KitCura
    //{

    //}

}
