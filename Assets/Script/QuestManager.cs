using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int questId;
    public int questActionIndex;
    public GameObject[] questObject;

    Dictionary<int, QuestData> questList;

    void Awake()
    {
        questList = new Dictionary<int, QuestData>();
        GenerateDate();
    }
        
    void GenerateDate()
    {
        questList.Add(10, new QuestData("sign the script on table", new int[] { 1000, 100}));

        questList.Add(20, new QuestData("search the pencil", new int[] { 100,200}));

        questList.Add(30, new QuestData("roam the town", new int[] { 0 }));

    }

    public int GetQuestTalkIndex(int id)
    {
        return questId + questActionIndex;

    }

    public string CheckQuest(int id)
    {

        if (id == questList[questId].npcId[questActionIndex])
            questActionIndex++;

        if (questActionIndex == questList[questId].npcId.Length)
            NextQuest();

        return questList[questId].questName;
    }

    public string CheckQuest()
    {
        return questList[questId].questName;
    }
    void NextQuest()
    {
        questId += 10;
        questActionIndex = 0;
    }

    
}
