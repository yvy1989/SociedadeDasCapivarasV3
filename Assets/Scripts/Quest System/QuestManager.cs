using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestManager : MonoBehaviour
{
    List<Quest> quests = new List<Quest>();

    int activeQuests;

    public GameObject UIQuest;
    public TextMeshProUGUI questTitle;
    public TextMeshProUGUI questDescription;

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
