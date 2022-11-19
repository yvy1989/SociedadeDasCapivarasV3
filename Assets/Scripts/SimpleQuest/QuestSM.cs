using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestSM : MonoBehaviour
{
    public int questID;
    public string questName;
    public bool complete;

    public int indice;

    int indiceGoalMax;
    public List<Goal> goals;

    public bool isQuestActive;

    private void Start()
    {

        /*
        foreach (var g in goals)
        {
            if(g != null){

                g.Init();

            }
            else
            {
                g.isComplete = true;
            }
        }
        */

        if (goals[indice] != null)
        {
            goals[indice].Init();
        }
        else
        {
            goals[indice].isComplete = true;
        }

    }

    private void Update()
    {

        if (isQuestActive)
        {
            if (complete)
            {
                return;
            }

            /*
            foreach (var g in goals)
            {
                if(g != null && g.goalAct != null){

                    g.Gupdate();

                }
                else
                {
                    g.isComplete = true;
                }
            }
            */

            if (goals[indice] != null)
            {

                if (goals[indice].isComplete == true)
                {
                    indice++;
                    indice = Mathf.Clamp(indice, 0, goals.Count - 1);
                    goals[indice].Init();
                    return;
                }

                goals[indice].Gupdate();

            }

            if (CheckAllGoalsComplete())
            {
                complete = true;
            }
        }

    }

    bool CheckAllGoalsComplete()
    {

        bool result = false;

        foreach (var g in goals)
        {
            if (g.isComplete)
            {
                result = true;
            }
            else
            {
                result = false;
                break;
            }
        }

        return result;

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UIQuestManager questManagerUI = gameObject.GetComponentInParent<UIQuestManager>();
            if (questManagerUI != null)
            {
                questManagerUI.logPanel.SetActive(true);
                questManagerUI.LogQuestDescription.text = "";
                foreach (var goal in goals)
                {
                    questManagerUI.LogQuestDescription.text += goal.description;
                    questManagerUI.LogQuestDescription.text += "\n\n";

                }

                questManagerUI.CurrentQuest_id = questID;

                if (isQuestActive) // evita de o painel de log ficar ativo mesmo voce aceitando a quest
                {
                    questManagerUI.logPanel.SetActive(false);
                }


            }            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UIQuestManager questManagerUI = gameObject.GetComponentInParent<UIQuestManager>();
            if (questManagerUI != null)
            {
                questManagerUI.logPanel.SetActive(false);
                
            }

        }
    }

}