using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MastermindMinigame : MonoBehaviour
{
    bool minigameIsActive = false;
    [SerializeField] private GameObject minigameObject;
    public List<Sprite>Buttons = new List<Sprite>();
    public List<Texture2D>Cursors = new List<Texture2D>();

    [SerializeField] private int selectedColour = 0;

    [SerializeField] private GameObject clickedButton;
    [SerializeField] private ColourIndex clickedColour;

    public void startMastermindMinigame()
    {
        minigameIsActive = true;
        Cursor.lockState = CursorLockMode.None;
        minigameObject.SetActive(true);
        Time.timeScale = 0f;
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
}
