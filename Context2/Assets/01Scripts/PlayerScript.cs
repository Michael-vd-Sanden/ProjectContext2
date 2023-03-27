using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject player;
    public GameObject insideSpawn;
    public GameObject outsideSpawn;

    public SceneManagement sceneManagement;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "GoInsideTrigger")
        {
            player.transform.position = insideSpawn.transform.position;
            //sceneManagement.loadInside();
        }
        if(other.tag == "GoOutsideTrigger")
        {
            player.transform.position = outsideSpawn.transform.position;
            //sceneManagement.loadOutside();
        }
    }
}
