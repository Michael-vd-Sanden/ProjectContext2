using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MasterRowScript : MonoBehaviour
{
    public MastermindMinigame mmm;
    private int round;
    public int rowIndex;
    public GameObject greybar;

    public List<Button> buttons;

    private void Update()
    {
        round = mmm.playRound;
        if (round == rowIndex)
        {
            greybar.SetActive(false);
            foreach (Button b in buttons)
            {
                b.interactable = true;
            }
        }
        else if (round != rowIndex)
        {
            greybar.SetActive(true);
            foreach (Button b in buttons)
            {
                b.interactable = false;
            }
        }
    }

    public List<Image> giveColours()
    {
        List<Image> colours = new List<Image>();
        foreach(Button b in buttons)
        {
            colours.Add(b.image);
            
        }
        return colours;
    }
}
