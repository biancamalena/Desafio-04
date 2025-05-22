using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public enum STATE
{
    DISABLE,
    WAITING,
    TYPING,
}

public class DialogueSystem : MonoBehaviour
{

    public DialogueData dialogueData;

    int currentText = 0;
    bool finishied = false;


    TypeTextAnimation typeText;
    STATE state;

    void Awake()
    {
        typeText = FindAnyObjectByType<TypeTextAnimation>();
    }
    void Start()
    {
        state = STATE.DISABLE;
    }


    void Update()
    {


        if (state == STATE.DISABLE) return;

        switch (state)
        {
            case STATE.WAITING:
                WAITING();
                break;
            case STATE.TYPING:
                Typing();
                break;
        }
    }

    private void Typing()
    {
        throw new NotImplementedException();
    }

    public void Next()
    {

        typeText.fullText = dialogueData.talkScript[currentText++].text;

        if (currentText == dialogueData.talkScript.Count) finishied = true;

        typeText.StartTyping();
        state = STATE.TYPING;
    }
    void WAITING()
    {
        void TYPING()
        {

        }
    }

}