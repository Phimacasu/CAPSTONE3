using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCInteraction : MonoBehaviour
{
    public GameObject pauseScreen;
    public Text powerUpText;

    private bool questCompleted;
    private bool powerUpUnlocked;
    private bool playerTalkedToNPC;

    private void Start()
    {
        // Initialize the flags and hide the pause screen
        questCompleted = false;
        powerUpUnlocked = false;
        playerTalkedToNPC = false;
        pauseScreen.SetActive(false);
    }

    private void Update()
    {
        // Check for player interaction
        if (Input.GetKeyDown(KeyCode.E) && playerTalkedToNPC && !questCompleted)
        {
            CompleteQuest(); // Call the quest completion function
        }
    }

    public void CompleteQuest()
    {
        // Perform quest completion logic
        questCompleted = true;
        powerUpUnlocked = true;
        pauseScreen.SetActive(true);
        powerUpText.text = "You unlocked a new power-up!";

        // Prevent player progression until they talk to the NPC again
        playerTalkedToNPC = false;
    }

    public void TalkToNPC()
    {
        // Allow the player to talk to the NPC
        playerTalkedToNPC = true;
    }

    public void ContinueToNextLevel()
    {
        // Perform the logic to load the next level
        // ...
    }
}
