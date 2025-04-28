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
        talkData.Add(1000, new string[] {"Hello?:0","are you coming first here?:2"});

        talkData.Add(100, new string[] {"What are you looking at? I'm just Table—so what?" });
        talkData.Add(200, new string[] { "It is just box" });

        talkData.Add(10 + 1000, new string[] { "Welcome to my town:0", "and you must sign script on table:1" });
        talkData.Add(11 + 1000, new string[] { "Welcome to my town:2", "so..roam in here?:1" });

        talkData.Add(11+100, new string[] { "sign? want a sign? but that is no pencil", 
                                              "you take the pencil and come to here" });

        talkData.Add(20 + 1000, new string[] { "what? pencil?? :1","Oh I forgot that haha..:2","look at the box that is there:0"});
        
        talkData.Add(20 + 200, new string[] {"there is pencil in box"});

        talkData.Add(20 + 100, new string[] { "you sign the script on table" });


        portraitData.Add(1000 + 0, portraiArr[0]);
        portraitData.Add(1000 + 1, portraiArr[1]);
        portraitData.Add(1000 + 2, portraiArr[2]);
        portraitData.Add(1000 + 3, portraiArr[3]);
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (!talkData.ContainsKey(id))
        {
            if (!talkData.ContainsKey(id - (id % 10) * 10)){
                return GetTalk(id - (id % 100), talkIndex);
            }
            else{
                return GetTalk(id - (id % 10) * 10, talkIndex); 
            }
            
        }


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
