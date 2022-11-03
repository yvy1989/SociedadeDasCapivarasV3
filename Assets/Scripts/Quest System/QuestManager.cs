using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{

    List<Quest> quests = new List<Quest>();

    public GameObject UIQuest;

    int activeQuests;

    // Start is called before the first frame update
    void Start()
    {
        activeQuests = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
