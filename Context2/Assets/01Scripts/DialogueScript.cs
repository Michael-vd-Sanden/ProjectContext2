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
    public NPCConversation breefingAfterConvoGood;
    public NPCConversation breefingAfterConvoBad;
    public bool hadBreefingAfter = false;

    public NPCConversation outsideBad;
    public bool hadOutsideBad = false;
    public NPCConversation creatureGoodConvo;
    public NPCConversation creatureBadConvo;
    public bool hadCreatureConvo = false;
    public NPCConversation badEnding;
    public bool hadBadEnding = false;
    public NPCConversation badToGoodEnding;
    public bool hadCreatureEndConvo = false;
    public NPCConversation creatureMiniGood;
    public NPCConversation creatureMiniBad;
    public bool hadCreatureMini = false;

    public NPCConversation reportConvo;
    public bool hadReport = false;
    public NPCConversation workerOut;
    public bool hadWorkerOut = false;
    public NPCConversation OAOut;
    public bool hadOAOut = false;
    public NPCConversation creatureGeologist;
    public bool hadGeologist = false;
    public NPCConversation geologistAfter;
    public bool hadGeologistAfter = false;
    public NPCConversation OAEnd;
    public bool hadOAEnd = false;

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

    public void switchGoodEnding()
    {
        isGoodEnding = !isGoodEnding;
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
            if(isGoodEnding)
            {
                manager.StartConversation(breefingAfterConvoGood);
            }
            else
            {
                manager.StartConversation(breefingAfterConvoBad);
            }
            hadBreefingAfter = true;
        }
        else if(!hadReport && hadBreefing && hadBreefingAfter && hadCreatureConvo)
        {
            manager.StartConversation(reportConvo);
            hadReport = true;
        }
        else if(!hadOAOut && hadReport && hadBreefingAfter && hadBreefing)
        {
            manager.StartConversation(OAOut);
            hadOAOut = true;
        }
        else if(!hadOAEnd && hadOAOut && hadReport && hadBreefingAfter && hadBreefing && hadGeologistAfter)
        {
            manager.StartConversation(OAEnd);
            hadOAEnd = true;
        }
    }

    public void startWorker()
    {
        if(!hadWorkerOut)
        {
            manager.StartConversation(workerOut);
            hadWorkerOut = true;
        }
    }

    public void startCreature()
    {
        if (isGoodEnding && !hadCreatureConvo)
        {
            manager.StartConversation(creatureGoodConvo);
            hadCreatureConvo = true;
            hadCreatureEndConvo = true;
        }
        else if (!isGoodEnding && !hadCreatureConvo)
        {
            manager.StartConversation(creatureBadConvo);
            hadCreatureConvo = true;
            hadBadEnding = true;
        }
        else if (!isGoodEnding && hadBadEnding && !hadCreatureEndConvo)
        {
            manager.StartConversation(badEnding);
            hadCreatureEndConvo = true;
        }
        else if(isGoodEnding && hadBadEnding && !hadCreatureEndConvo)
        {
            manager.StartConversation(badToGoodEnding);
            hadCreatureEndConvo = true;
        }
        else if(!isGoodEnding && hadCreatureConvo && !hadCreatureMini)
        {
            manager.StartConversation(creatureMiniBad);
            hadCreatureMini = true;
        }
        else if(isGoodEnding && hadCreatureConvo && !hadCreatureMini)
        {
            manager.StartConversation(creatureMiniGood);
            hadCreatureMini = true;
        }
        else if (!hadGeologist && hadCreatureConvo && hadCreatureEndConvo && hadCreatureMini && hadReport && hadOAOut)
        {
            manager.StartConversation(creatureGeologist);
            hadGeologist = true;
        }
        else if(!hadGeologistAfter && hadGeologist && hadCreatureConvo && hadCreatureEndConvo && hadCreatureMini)
        {
            manager.StartConversation(geologistAfter);
            hadGeologistAfter = true;
        }

    }

    public void startAngry1()
    {
        manager.EndConversation();
        StartCoroutine(startAngry());
    }
    public IEnumerator startAngry()
    {
        yield return new WaitForSeconds(0.5f);
        if(!hadOutsideBad)
        {
            manager.StartConversation(outsideBad);
        }
        hadOutsideBad = true;
    }
}
