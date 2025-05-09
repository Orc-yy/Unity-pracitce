using NUnit.Framework.Internal;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TypeEffect talk;
    public Text questText;
    public QuestManager questManager;
    public GameObject scanObject;
    public GameObject menuSet;
    public GameObject player;
    public Animator talkPanel;
    public Animator portraitAnim;
    public Sprite prevPortrait;
    public bool isAction;
    public TalkManger talkManager;
    public int talkIndex;
    public Image portraitImg;
   

    private void Start()
    {
        GameLoad();
        questText.text = questManager.CheckQuest();
    }
    private void Update()
    {
        //SubMenu
        if (Input.GetButtonDown("Cancel"))
            SubMenuActive();
    }

    public void SubMenuActive()
    {
        if (menuSet.activeSelf)
            menuSet.SetActive(false);
        else
            menuSet.SetActive(true);
    }

    public void Action(GameObject scanObj)
    {
          scanObject = scanObj;
          ObjectDate objectDate = scanObject.GetComponent<ObjectDate>();
          Talk(objectDate.id, objectDate.isNpc);
        
        talkPanel.SetBool("isShow",isAction);
    }
    
    void Talk(int id, bool isNpc)
    {
        int questTalkIndex = 0;
        string talkData = "";
        if (talk.isAnim)
        {
            talk.SetMsg("");
            return;
        }
            
        else
        {
             questTalkIndex = questManager.GetQuestTalkIndex(id);
             talkData = talkManager.GetTalk(id + questTalkIndex, talkIndex);
        }
            

        if (talkData == null)
        {
            isAction = false;
            talkIndex = 0;
            questText.text = questManager.CheckQuest(id);
            return;
        }

        if (isNpc)
        {
            talk.SetMsg(talkData.Split(':')[0]);

            portraitImg.sprite = talkManager.GetPortrait(id, int.Parse(talkData.Split(':')[1]));
            portraitImg.color = new Color(1, 1, 1, 1);
            // Animation Portrait
            if(prevPortrait != portraitImg.sprite) 
            {
                portraitAnim.SetTrigger("doEffect");
                prevPortrait = portraitImg.sprite;
            }
                
        }
        else
        {
            talk.SetMsg(talkData);
            portraitImg.color = new Color(1, 1, 1, 0);
        }

        isAction = true;
        talkIndex++;
    }

    public void GameExit()
    {
        Application.Quit();
    }

    public void GameSave()
    {
        PlayerPrefs.SetFloat("PlayerX",player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", player.transform.position.y);
        PlayerPrefs.SetInt("QuestId", questManager.questId);
        PlayerPrefs.SetInt("QuestActionIndex", questManager.questActionIndex);
        PlayerPrefs.Save();

        menuSet.SetActive(false);
    }
    public void GameLoad()
    {
        if (!PlayerPrefs.HasKey("PlayerX"))
            return;

        float x = PlayerPrefs.GetFloat("PlayerX");
        float y = PlayerPrefs.GetFloat("PlayerY");
        int questId = PlayerPrefs.GetInt("QuestId");
        int questActionIndex = PlayerPrefs.GetInt("QuestActionIndex");

        player.transform.position = new Vector3(x, y, -9);
        questManager.questId = questId;
        questManager.questActionIndex = questActionIndex;
    }
}
