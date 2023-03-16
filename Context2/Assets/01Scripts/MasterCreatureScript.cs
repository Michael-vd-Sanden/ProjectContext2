using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterCreatureScript : MonoBehaviour
{
    public int minigameLevel = 0;
    public GameObject level0;
    public GameObject level1;
    public GameObject level2;
    public GameObject level3;
    public int rowNeedsMet;

    public Button submitButton;
    public MastermindMinigame mmm;

    public bool hasTheirNeeds = false;

    private void Update()
    {
        if(mmm.playRound >= rowNeedsMet)
        {
            submitButton.interactable = true;
        }
        else
        {
            submitButton.interactable = false;
        }
    }

    public void RoundSelector()
    {
        switch (minigameLevel) 
        {
            case 0:
                rowNeedsMet = 3;
                level0.SetActive(true);
                level1.SetActive(false);
                level2.SetActive(false);
                level3.SetActive(false);
                break;
            case 1:
                rowNeedsMet = 5;
                level0.SetActive(false);
                level1.SetActive(true);
                level2.SetActive(false);
                level3.SetActive(false);
                break;
            case 2:
                rowNeedsMet = 1;
                level0.SetActive(false);
                level1.SetActive(false);
                level2.SetActive(true);
                level3.SetActive(false);
                break;
            case 3:
                rowNeedsMet = 7;
                level0.SetActive(false);
                level1.SetActive(false);
                level2.SetActive(false);
                level3.SetActive(true);
                break;
        }

    }

}
