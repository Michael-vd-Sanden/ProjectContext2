using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
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

    public void LoadTreeCreatures()
    {
        SceneManager.LoadScene("CTree", LoadSceneMode.Additive);
    }
}
