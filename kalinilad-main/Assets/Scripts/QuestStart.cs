using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestStart : MonoBehaviour
{
    public GameObject questStartDialogueTrigger;
    public GameObject questItemPrefab;
    public GameObject npc;
    public GameObject keyPrefab;
    public GameObject player;

    private bool hasQuestItem = false;
    private bool isDialogueTriggered = false;
    private bool isQuestCompleted = false;
    private GameObject questItemInstance;
    private GameObject keyInstance;
    private PlayerController playerController;

    private void Start()
    {
        playerController = player.GetComponent<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("QuestStart") && !isQuestCompleted)
        {
            if (!isDialogueTriggered)
            {
                // Disable player movement
                if (playerController != null)
                {
                    playerController.DisableMovement();
                }

                // Trigger quest start dialogue
                questStartDialogueTrigger.GetComponent<DialogueTrigger>().StartDialogue();
                isDialogueTriggered = true;
            }
        }
        else if (other.CompareTag("NPC") && hasQuestItem && !isQuestCompleted)
        {
            // Interact with NPC to complete quest
            CompleteQuest();
        }
    }

    public void PlayerHasQuestItem()
    {
        hasQuestItem = true;

        // Create and enable the quest item prefab
        if (questItemPrefab != null && questItemInstance == null)
        {
            questItemInstance = Instantiate(questItemPrefab, player.transform.position, Quaternion.identity);
        }
    }

    private void CompleteQuest()
    {
        if (hasQuestItem)
        {
            // Destroy the quest item following the player
            if (questItemInstance != null)
            {
                Destroy(questItemInstance);
            }

            // Create and enable the key prefab
            if (keyPrefab != null && keyInstance == null)
            {
                keyInstance = Instantiate(keyPrefab);
                //keyInstance.GetComponent<Key>().followTarget(player.transform);
            }

            // Enable player movement
            if (playerController != null)
            {
                playerController.EnableMovement();
            }

            isQuestCompleted = true;
        }
        else
        {
            // Display "You don't have the Quest Item yet" text or perform other actions
        }
    }
}
