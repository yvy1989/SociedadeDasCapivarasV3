using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShowIngredients : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private Image[] ingredients;

    [SerializeField]
    private Sprite transparent;

    private void Start()
    {
        ToggleIngredientsActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ToggleIngredientsActive(true);
        Debug.Log("In");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ToggleIngredientsActive(false);
        Debug.Log("Out");
    }

    private void ToggleIngredientsActive(bool active)
    {
        foreach (Image item in ingredients)
        {
            if (active)
            {
                //item.color = new Color(1, 1, 1, 1);
                item.overrideSprite = null;
                item.raycastTarget = true;
            }
            else
            {
                //item.color = new Color(1, 1, 1, 0);
                item.overrideSprite = transparent;
                item.raycastTarget = false;
            }
        }
        Canvas.ForceUpdateCanvases();
    }
}
