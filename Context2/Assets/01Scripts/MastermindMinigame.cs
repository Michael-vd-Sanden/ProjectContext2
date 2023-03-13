using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MastermindMinigame : MonoBehaviour
{
    public bool minigameIsActive = false;
    [SerializeField] private GameObject minigameObject;
    public List<Sprite>Buttons = new List<Sprite>();
    public List<Texture2D>Cursors = new List<Texture2D>();
    public List<MasterRowScript> Rows;

    [SerializeField] private int selectedColour = 0;

    [SerializeField] private GameObject clickedButton;
    [SerializeField] private ColourIndex clickedColour;

    public int playRound = 0;

    public List<string> colourNames;
    public List<string> colourCode;

    public void startMastermindMinigame()
    {
        minigameIsActive = true;
        playRound = 0;

        var colourCodeNames = new List<string>(colourNames);
        for (int i = 0; i < 4; i++)
        {
            int r = Random.Range(0, colourCodeNames.Count);
            colourCode.Add(colourCodeNames[r]);
            colourCodeNames.RemoveAt(r);
        }
        foreach (string c in colourCode)
        {
            Debug.Log(c);
        }
        foreach (MasterRowScript m in Rows)
        {
            m.resetColours();
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.SetCursor(Cursors[selectedColour], Vector2.zero, CursorMode.Auto);
        minigameObject.SetActive(true);
        Time.timeScale = 0f;
    }
    public void stopMastermindMinigame()
    {
        minigameIsActive = false;
        Cursor.lockState = CursorLockMode.Locked;
        colourCode.Clear(); 
        minigameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ClickedButton()
    {
        Image btnColour = clickedButton.GetComponent<Image>();
        btnColour.sprite = Buttons[selectedColour];
    }

    public void setClickedButton(GameObject btn)
    {
        clickedButton = btn;
    }

    public void setClickedColour(ColourIndex index)
    {
        clickedColour = index;
        selectedColour = clickedColour.colourIndex;
        Cursor.SetCursor(Cursors[selectedColour], Vector2.zero, CursorMode.Auto);
    }

    public void checkAnswer()
    {
        MasterRowScript m = Rows[playRound];
        List<Image> givenColours = m.giveColours();
        List<string> colourname = new List<string>();
        foreach(Image img in givenColours)
        {
            colourname.Add(img.sprite.name);
        }

        List<string> noDupes = colourname.Distinct().ToList();
        if (noDupes.Count < 4)
        {
            Debug.Log("row not filled in correctly, duped");
            return;
        }
        else
        {
            giveScore();
        }
        if (minigameIsActive)
        {
            for (int i = 0; i < givenColours.Count; i++)
            {
                if (givenColours[i].sprite.name == "BtnEmpty")
                {
                    Debug.Log("row not filled in correctly");
                    return;
                }
                if (givenColours[i].sprite.name != colourCode[i])
                {
                    Debug.Log("incorrect");
                    if (playRound != 8)
                    {
                        playRound++;
                    }
                    else
                    {
                        Debug.Log("you lose!");
                        stopMastermindMinigame();
                    }
                    return;
                }

            }
        }
    }

    public void giveScore()
    {
        int red = 0;
        int black = 0;
        int white = 0;
        MasterRowScript m = Rows[playRound];
        List<Image> givenColours = m.giveColours();
        for (int i = 0; i < givenColours.Count; i++)
        {
            string check = givenColours[i].sprite.name;
            if (check == colourCode[i])
            {
                red++;
            }
            else if(check == colourCode[0] || check == colourCode[1] || check == colourCode[2] || check == colourCode[3] )
            {
                black++;
            }
            else
            {
                white++;
            }
        }
        if (red == 4)
        {
            stopMastermindMinigame();
            Debug.Log("You won");
        }

        Debug.Log(red + " " + black + " " + white);

        for (int i = 0; i < m.checkColours.Count; i++)
        {
            if(red > 0)
            {
                m.checkColours[i].color = Color.red;
                red --;
            }
            else if(black > 0) 
            {
                m.checkColours[i].color = Color.black;
                black --;
            }
            else if (white > 0)
            {
                m.checkColours[i].color = Color.white;
                white --;
            }
        }
    }
}
