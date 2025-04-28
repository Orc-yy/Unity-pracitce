using UnityEngine;
using UnityEngine.UI;

public class TypeEffect : MonoBehaviour
{
    string tragetMsg;
    public int CharPerSeconds;
    public GameObject EndCursor;
    public bool isAnim;

    Text msgText;
    AudioSource audioSourec;
    int index;
    float interval;

    private void Awake()
    {
        msgText = GetComponent<Text>();
        audioSourec = GetComponent<AudioSource>();
    }
    public void SetMsg(string msg)
    {
        if (isAnim)
        {
            msgText.text = tragetMsg;
            CancelInvoke();
            EffectEnd();
        }
        else
        {
            tragetMsg = msg;
            EffectStart();
        }
            
    }

    void EffectStart()
    {
        msgText.text = "";
        index = 0;
        EndCursor.SetActive(false);

        interval = 1.0f / CharPerSeconds;

        isAnim = true;
        Invoke("Effecting", interval);

    }
    void Effecting()
    {
        if(msgText.text == tragetMsg)
        {
            EffectEnd();
            return;
        }

        msgText.text += tragetMsg[index];

        //Sound
        if (tragetMsg[index] != ' ' || tragetMsg[index] != '.')
            audioSourec.Play();

        index++;

        Invoke("Effecting", interval);
    }
    void EffectEnd()
    {
        isAnim = false;
        EndCursor.SetActive(true);
    }

}
