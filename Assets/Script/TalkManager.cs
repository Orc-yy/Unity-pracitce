using System.Collections.Generic;
using UnityEngine;

public class TalkManger : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;

    public Sprite[] portraiArr;
    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        GenerateDate();
    }

    // Update is called once per frame
    void GenerateDate()
    {
        talkData.Add(1000, new string[] {"Hello?:0","are you coming first here?:1"});

        talkData.Add(100, new string[] {"What are you looking at? I'm just Table—so what?" });

        portraitData.Add(1000 + 0, portraiArr[0]);
        portraitData.Add(1000 + 1, portraiArr[1]);
        portraitData.Add(1000 + 2, portraiArr[2]);
        portraitData.Add(1000 + 3, portraiArr[3]);
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length)
            return null;
        else 
            return talkData[id][talkIndex];
    }

    public Sprite GetPortrait(int id, int portraitIndex)
    {
        return portraitData[id + portraitIndex];
    }
    
}
