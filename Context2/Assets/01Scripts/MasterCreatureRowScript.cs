using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterCreatureRowScript : MonoBehaviour
{
    public MastermindMinigame mmm;
    private int round;
    public int rowIndex;
    public GameObject greybar;
    public GameObject score;
    public Sprite startImage;

    public List<Image> buttons;
    public List<Image> checkColours;

    private void Update()
    {
        round = mmm.playRound - 1;
        if(round >= rowIndex)
        {
            score.SetActive(true);
            greybar.SetActive(false);
        }
        else
        { 
            score.SetActive(false);
            greybar.SetActive(true);
        }
    }
}
