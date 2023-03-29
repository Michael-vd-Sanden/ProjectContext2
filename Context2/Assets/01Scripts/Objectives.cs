using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Objectives : MonoBehaviour
{
    public TMP_Text objectiveText;
    public GameObject objectivesObject;
    public MastermindMinigame mmm;

    public int objectiveCount = 0;
    public string objective;

    private void Start()
    {
        objective = "Go to the main building for further instructions";
    }

    private void Update()
    {
        objectiveText.text = objective;
        if(mmm.minigameIsActive)
        {
            objectivesObject.SetActive(false);
        }
        else
        {
            objectivesObject.SetActive(true);
        }
    }

    public void updateObjective()
    {
        objectiveCount++;
        switch (objectiveCount)
        {
            case 1: objective = "Talk to the Operations Advisor";
                break;
            case 2: objective = "Go to the buildsite";
                break;
            case 3: objective = "Talk to the creature";
                break;
            case 4: objective = "Report back to the Oparations Advisor";
                break;
            case 5: objective = "Talk to the Operations Advisor";
                break;
            case 6: objective = "Talk to the creature";
                break;
            case 7: objective = "Talk to the Operations Advisor";
                break;
        }
    }
}
