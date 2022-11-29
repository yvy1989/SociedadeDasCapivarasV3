using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Cinemachine;
using System;

public class UIQuestManager : MonoBehaviour
{
    public CinemachineFreeLook cam; //camera do cinemachine para travar o freelock durante o menu de craft

    public static Action<bool> isCurrentQuesDone;


    //public bool activeQestComplete;
    public QuestSM.QuestProgress activeQuestProgress;

    //ACTIVE PANEL

    public Toggle QuestStatusToogle;
    public GameObject ActiveQuestPanel;
    public GameObject goalPrefabPanel;
    public Transform GoalsSpacer;
    public Goal[] Goals;
    List<GameObject> goalPanels = new List<GameObject>();


    public int CurrentQuest_id;

    /// LOG PANEL ////////////////////////////
    public GameObject logPanel;
    public TextMeshProUGUI LogQuestDescription;
    public Button AcceptQuestBtn;
        

    public static UIQuestManager Instance;

    QuestSM[] Quests;


    public void startQuestByID()
    {
        Quests = GetComponentsInChildren<QuestSM>();
        if (Quests != null)
        {
            foreach (var _quest in Quests)
            {
                if(_quest.questID == CurrentQuest_id)
                {
                    if(_quest.progress == QuestSM.QuestProgress.COMPLETE)
                    {
                        
                        Debug.Log("Recebeu o item!!"); //entregar item de recompensa e passar status para done
                        SpanwItenByName(_quest.rewardItem, _quest.spawnItemLocation.position);

                        //resetar painel activeQuest
                        QuestStatusToogle.isOn = false;
                        if (isCurrentQuesDone != null)
                        {
                            isCurrentQuesDone(true);
                        }

                        _quest.progress = QuestSM.QuestProgress.DONE;
                        logPanel.SetActive(false); //desabilita o painel de log
                        freezeOrReleaseCam(false);//libera a camera
                        return;
                    }
                    _quest.progress = QuestSM.QuestProgress.ACCEPTED; //aceita a quest
                }
            }

        }

        foreach (Goal _goal in Goals)// varre a lista de goals e instancia um painel para cada objetivo da quest
        {
            GameObject goalPanel = Instantiate(goalPrefabPanel, GoalsSpacer);
            goalPanel.GetComponent<UIGoal>().TxtGoalDescription.text = _goal.description;
            goalPanel.GetComponent<UIGoal>().goalStatusToogle.isOn = _goal.isComplete;
            goalPanel.GetComponent<UIGoal>().goalIndex = _goal.goalIndex;
            goalPanels.Add(goalPanel);

        }
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))// abre o painel de quest ativa
        {
            ActiveQuestPanel.SetActive(!ActiveQuestPanel.active);
        }


        if(activeQuestProgress!= QuestSM.QuestProgress.COMPLETE || activeQuestProgress != QuestSM.QuestProgress.DONE) // entra aqui se a quest ainda nao estiver terminada
        {
            if (goalPanels != null)
            {
                foreach (Goal _goal in Goals)
                {
                    foreach (var _goalPanel in goalPanels)
                    {
                        if (_goalPanel != null)
                        {
                            UIGoal uiGoal;
                            uiGoal = _goalPanel.GetComponent<UIGoal>();
                            if (_goal.goalIndex == uiGoal.goalIndex)
                            {
                                uiGoal.goalStatusToogle.isOn = _goal.isComplete;
                            }
                        }
                        
                        
                    }
                }
            }


            if (Quests != null)
            {
                foreach (var _quest in Quests)
                {
                    if (_quest.questID == CurrentQuest_id)
                    {
                        activeQuestProgress = _quest.progress;
                        if(activeQuestProgress == QuestSM.QuestProgress.COMPLETE)
                        {
                            QuestStatusToogle.isOn = true;
                        }
                        
                    }
                }

            }
        }
        
    }

    private void SpanwItenByName(Item itemToReward, Vector3 spawnLocation)
    {
        itemToReward = GameManager.instance.itemManager.GetItemByName(itemToReward.data.itemName);

        if (itemToReward != null)
        {

            Item droppedItem = Instantiate(itemToReward, spawnLocation, Quaternion.identity);

        }
    }


    public void freezeOrReleaseCam(bool value)
    {
        if (value)
        {
            if (cam != null)
            {
                cam.m_YAxis.m_MaxSpeed = 0;
                cam.m_XAxis.m_MaxSpeed = 0;
            }
        }
        else
        {
            if (cam != null)
            {
                cam.m_YAxis.m_MaxSpeed = 5;
                cam.m_XAxis.m_MaxSpeed = 300;
            }
        }
        
    }
}
