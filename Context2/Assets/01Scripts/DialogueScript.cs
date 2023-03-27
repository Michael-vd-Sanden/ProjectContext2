using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class DialogueScript : MonoBehaviour
{
    public ConversationManager manager;
    public NPCConversation startingConvo;

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
        else
        {
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
