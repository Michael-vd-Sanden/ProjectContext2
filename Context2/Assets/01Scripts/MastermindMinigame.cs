using System.Collections;
using System.Collections.Generic;
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
        for (int i = 0; i < 4; i++)
        {
            int r = Random.Range(0, 6);
            colourCode.Add(colourNames[r]);
        }
        foreach (string c in colourCode)
        {
            Debug.Log(c);
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.SetCursor(Cursors[selectedColour], Vector2.zero, CursorMode.Auto);
        minigameObject.SetActive(true);
        Time.timeScale = 0f;
    }
    public void stopMastermindMinigame()
    {
        minigameIsActive= false;
        Cursor.lockState = CursorLockMode.Locked;
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
        for(int i = 0; i < givenColours.Count; i++)
        {
            if (givenColours[i].sprite.name == "BtnEmpty")
            {
                Debug.Log("row not filled in correctly");
                return;
            }
            if (givenColours[i].sprite.name != colourCode[i])
            {
                Debug.Log("incorrect");
                playRound++;
                return;
            }
            
        }
        Debug.Log("you win!");
        stopMastermindMinigame();
    }
}
