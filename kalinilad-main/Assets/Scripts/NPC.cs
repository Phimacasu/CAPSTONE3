using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField]
    DialogueTrigger[] trigger;

    [SerializeField]
    int rngMaxSetDialogues = 1;

    int indSetDialogue;

    bool stateHasPlayer = false;

    // Start is called before the first frame update
    void Start()
    {
        trigger = GetComponents<DialogueTrigger>();
    }

    // Update is called once per frame
    void Update()
    {
        Speaking();
    }

    private void Speaking()
    {
        if (!stateHasPlayer)
            return;

        if (!Input.GetKeyDown(KeyCode.E))
            return;

        if (!DialogueManager.stateCanTalk)
            return;

        indSetDialogue = Random.Range(0, rngMaxSetDialogues);
        trigger[indSetDialogue].StartDialogue();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            stateHasPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            stateHasPlayer = false;
        }
    }
}
