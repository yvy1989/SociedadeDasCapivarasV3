using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestSM : MonoBehaviour
{
    public int questID;
    public string questName;

    //public bool complete;
    public Item rewardItem;
    public Transform spawnItemLocation;

    public enum QuestProgress { AVAILABLE, ACCEPTED, COMPLETE, DONE }
    public QuestProgress progress;

    public int indice;

    int indiceGoalMax;
    public List<Goal> goals;


    private void Start()
    {
        progress = QuestProgress.AVAILABLE;
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

        if (progress == QuestSM.QuestProgress.ACCEPTED)
        {
            if (progress == QuestProgress.COMPLETE)
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
                //complete = true;
                progress = QuestProgress.COMPLETE;
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
            if (questManagerUI != null && progress != QuestProgress.DONE) //verifica se a quest nao esta finalizada
            {
                questManagerUI.logPanel.SetActive(true); //ativa o painel de log
                questManagerUI.freezeOrReleaseCam(true);// trava a camera


                if (progress != QuestProgress.COMPLETE)
                {
                    questManagerUI.LogQuestDescription.text = ""; //apaga o texto do paainel de LOG
                    foreach (var goal in goals)
                    {
                        questManagerUI.LogQuestDescription.text += goal.description;
                        questManagerUI.LogQuestDescription.text += "\n\n"; //pula duas linhas caso a quest tenha mais de um objetivo

                    }

                    questManagerUI.CurrentQuest_id = questID; // passa a ID da quest para o questManagerUI
                    questManagerUI.Goals = goals.ToArray(); // passa os objetivos para o questManagerUI

                    if (progress == QuestProgress.ACCEPTED) // evita de o painel de log ficar ativo mesmo voce aceitando a quest
                    {
                        questManagerUI.logPanel.SetActive(false);
                        questManagerUI.freezeOrReleaseCam(false);//libera a camera
                    }
                }
                else
                {
                    //mudar para painel de parabens
                    questManagerUI.LogQuestDescription.text = "Parabens Voce Terminou a Tarefa\n Receba esta recompensa!";

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
                questManagerUI.freezeOrReleaseCam(false);//libera a camera

            }

        }
    }

}
