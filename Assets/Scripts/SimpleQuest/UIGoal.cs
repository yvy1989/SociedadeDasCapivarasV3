using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIGoal : MonoBehaviour
{
    public int goalIndex;
    public TextMeshProUGUI TxtGoalDescription;
    public Toggle goalStatusToogle;


    private void OnEnable()
    {
        UIQuestManager.isCurrentQuesDone += resetValues;
    }

    private void Update()
    {

    }

    private void resetValues(bool isDone)
    {
        if (isDone)
        {
            TxtGoalDescription.text = "";
            goalStatusToogle.isOn = false;
            Destroy(this);

        }
        
    }
}
