using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public DialogueScript dialogue;

    private void Start()
    {
        SceneManager.LoadScene("Inside_Building", LoadSceneMode.Additive);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("quit");
    }

    public void LoadAngryCreatures()
    {
        SceneManager.LoadScene("CAngry", LoadSceneMode.Additive);
    }

    public void LoadCreaturesOut()
    {
        SceneManager.LoadScene("COut", LoadSceneMode.Additive);
    }

    public void setInsideActive()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Inside_Building"));
    }
    public void setOutsideActive() 
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("SharonScene"));
    }

    public void UnloadScenes()
    {
        if(dialogue.hadBadEnding)
        {
            SceneManager.UnloadSceneAsync("CAngry");
        }
        else
        {
            SceneManager.UnloadSceneAsync("CTree");
        }
        
    }

    public void LoadTreeCreatures()
    {
        SceneManager.LoadScene("CTree", LoadSceneMode.Additive);
    }
}
