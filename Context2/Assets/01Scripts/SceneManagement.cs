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
}
