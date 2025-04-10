using NUnit.Framework.Internal;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text TalkText;
    public GameObject scanObject;
    public GameObject talkPanel;
    public bool isAction;
    public TalkManger talkManager;
    public int talkIndex;
    public Image portraitImg;

  

    public void Action(GameObject scanObj)
    {
          scanObject = scanObj;
          ObjectDate objectDate = scanObject.GetComponent<ObjectDate>();
          Talk(objectDate.id, objectDate.isNpc);
        
        talkPanel.SetActive(isAction);
    }
    
    void Talk(int id, bool isNpc)
    {
        string talkData = talkManager.GetTalk(id, talkIndex);

        if (talkData == null)
        {
            isAction = false;
            talkIndex = 0; 
            return;
        }

        if (isNpc)
        {
            TalkText.text = talkData.Split(':')[0];

            portraitImg.sprite = talkManager.GetPortrait(id, int.Parse(talkData.Split(':')[1]));
            portraitImg.color = new Color(1, 1, 1, 1);
        }
        else
        {
            TalkText.text = talkData;
            portraitImg.color = new Color(1, 1, 1, 0);
        }

        isAction = true;
        talkIndex++;
    }   


}
