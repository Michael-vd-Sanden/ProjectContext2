using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject player;
    public GameObject insideSpawn;
    public GameObject outsideSpawn;

    public SceneManagement sceneManagement;
    public DialogueScript dialogue;

    [SerializeField] private MastermindMinigame mmMinigame;
    [SerializeField] private MasterCreatureScript mCreature;

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

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 5f))
            {
                if (hit.transform.gameObject.tag == "OA")
                {
                    if (!dialogue.checkIfActive())
                    {
                        dialogue.startBreefing();
                    }
                }
            }
        }
    }

    public void startTrigger(int level)
    {
        StartCoroutine(triggerMinigame(level));
    }
    public IEnumerator triggerMinigame(int level)
    {
        yield return new WaitForSecondsRealtime(1f);
        mCreature.minigameLevel = level;
        if(!mmMinigame.minigameIsActive)
        {
            mmMinigame.startMastermindMinigame();
        }
    }
}
