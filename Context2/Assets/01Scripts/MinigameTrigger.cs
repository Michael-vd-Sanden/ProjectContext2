using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameTrigger : MonoBehaviour
{
    [SerializeField] private MastermindMinigame mmMinigame;
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 5f))
            {
                if(hit.transform.gameObject.tag == "MastermindTrigger")
                {
                    //start mastermind Minigame
                    if (!mmMinigame.minigameIsActive)
                    {
                        mmMinigame.startMastermindMinigame();
                    }
                }
            }
        }
    }
}
