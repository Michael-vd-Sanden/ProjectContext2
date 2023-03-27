using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class DialogueScript : MonoBehaviour
{
    public bool isGoodEnding = true;

    public ConversationManager manager;
    public NPCConversation startingConvo;
    public NPCConversation breefingConvo;
    public bool hadBreefing = false;
    public NPCConversation breefingAfterConvo;
    public bool hadBreefingAfter = false;

    [SerializeField] private MastermindMinigame mmm;

    private void Start()
    {
        manager.StartConversation(startingConvo);
    }

    private void Update()
    {
        if(manager.IsConversationActive)
        {
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
        }
        else if(!manager.IsConversationActive && !mmm.minigameIsActive) 
        {
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
        }

        if(mmm.minigameIsActive) 
        {
            manager.EndConversation();
        }
    }

    public bool checkIfActive()
    {
        if (manager.IsConversationActive)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void stopConvo()
    {
        manager.EndConversation();
    }

    public void startBreefing()
    {
        if (!hadBreefing)
        {
            manager.StartConversation(breefingConvo);
            hadBreefing = true;
        }
        else if(hadBreefing && !hadBreefingAfter)
        {
            manager.StartConversation(breefingAfterConvo);
            hadBreefingAfter = true;
        }
    }

}
