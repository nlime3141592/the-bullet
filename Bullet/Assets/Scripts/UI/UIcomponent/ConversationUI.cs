using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConversationUI : UIcomponent
{
    GameObject Toggle_OneBt;
    GameObject Toggle_TwoBt;

    public delegate void ButtonFunction();

    public ButtonFunction event_ok;
    public ButtonFunction event_yes;
    public ButtonFunction event_no;

    public override void Initialize()
    {

    }

    protected override void Loop()
    {
        
    }

    public void ConversationInitialize(string ShowMessage, int buttonCount)
    {
        MessageGeneration(ShowMessage);
        ButtonGeneration(buttonCount);
    }

    // 보여줄 메세지를 설정
    void MessageGeneration(string Message)
    {
        foreach(Transform obj in gameObject.GetComponentsInChildren<Transform>())
        {
            if (obj.gameObject.name == "Textbox_Message")
            {
                obj.GetComponent<Text>().text = Message;
            }
        }
    }

    // 보여주고 싶은 버튼 갯수에 따라 버튼을 생성
    void ButtonGeneration(int button_count)
    {
        foreach(Transform obj in gameObject.GetComponentsInChildren<Transform>())
        {
            string objname = obj.gameObject.name;

            if(objname == "Toggle_OneButton")
            {
                Toggle_OneBt = obj.gameObject;
            }
            else if(objname == "Toggle_TwoButton")
            {
                Toggle_TwoBt = obj.gameObject;
            }
        }

        switch(button_count)
        {
            case 1:
                Toggle_OneBt.SetActive(true);
                Toggle_TwoBt.SetActive(false);
                break;

            case 2:
                Toggle_OneBt.SetActive(false);
                Toggle_TwoBt.SetActive(true);
                break;

            default:
                Toggle_OneBt.SetActive(true);
                Toggle_TwoBt.SetActive(false);
                break;
        }

    }
}