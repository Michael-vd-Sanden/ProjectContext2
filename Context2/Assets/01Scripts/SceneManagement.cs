using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public void loadInside()
    {
        SceneManager.LoadScene("Inside_Building", LoadSceneMode.Additive);
    }
    public void loadOutside()
    {
        SceneManager.LoadScene("SharonScene", LoadSceneMode.Additive);
    }
}
