using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    [SerializeField]
    DialogueTrigger[] trigger;

    [SerializeField]
    string typeQCollectible;

    [SerializeField]
    GameObject enemyQuest;

    bool stateHasPlayer = false;

    // Start is called before the first frame update
    void Start()
    {
        trigger = GetComponents<DialogueTrigger>();
    }

    // Update is called once per frame
    void Update()
    {
        Questing();   
    }

    private void Questing()
    {
        if (!stateHasPlayer)
            return;

        if (!Input.GetKeyDown(KeyCode.E))
            return;

        if (!DialogueManager.stateCanTalk)
            return;
        
        if (!PlayerPrefs.HasKey(typeQCollectible))
        {
            PlayerPrefs.SetInt(typeQCollectible, 0);
            Debug.LogWarning("You got " + typeQCollectible + " quest!");
            trigger[0].StartDialogue();
            return;
        }
        
        if (PlayerPrefs.GetInt(typeQCollectible) == 2)
        {
            Debug.LogError("You already finished " + typeQCollectible + " quest!");
            trigger[3].StartDialogue();
        }
        else if (PlayerPrefs.GetInt(typeQCollectible) == 1)
        {
            PlayerPrefs.SetInt(typeQCollectible, 2);

            if (enemyQuest != null)
                enemyQuest.SetActive(false);
            
            Debug.LogWarning("You finished " + typeQCollectible + " quest!");
            trigger[2].StartDialogue();
        }
        else
        {
            Debug.LogError("You have not finished " + typeQCollectible + " quest!");
            trigger[1].StartDialogue();
        }
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
