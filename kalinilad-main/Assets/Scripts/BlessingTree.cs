using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BlessingTree : MonoBehaviour
{
    public GameObject questItemPrefab;
    public GameObject pauseScreen;
    public Text blessingText;
    public Button blessingButton;
    public Button nextLevelButton;
    public string[] blessingSlots; // Array to hold the blessings for each level

    private bool questActive;
    private bool questItemObtained;
    private bool playerTalkedToNPC;
    private string currentLevel;

    private void Start()
    {
        // Initialize flags and UI elements
        questActive = false;
        questItemObtained = false;
        playerTalkedToNPC = false;
        pauseScreen.SetActive(false);
        blessingButton.interactable = false;
        nextLevelButton.interactable = false;
        blessingSlots = new string[4];
    }

    private void Update()
    {
        // Check for player interaction
        if (Input.GetKeyDown(KeyCode.E) && playerTalkedToNPC && questActive && !questItemObtained)
        {
            CheckForQuestItem(); // Call function to check for quest item
        }

        // Check if the player can progress to the next level
        if (Input.GetKeyDown(KeyCode.E) && playerTalkedToNPC && questActive && questItemObtained)
        {
            if (currentLevel == "Tutorial" && blessingSlots[0] != null)
            {
                UpdateBlessingText(blessingSlots[0]);
            }
            else if (currentLevel == "Tunnels" && blessingSlots[1] != null)
            {
                UpdateBlessingText(blessingSlots[1]);
            }
            else if (currentLevel == "Industrial Area" && blessingSlots[2] != null)
            {
                UpdateBlessingText(blessingSlots[2]);
            }
            else if (currentLevel == "Commercial District" && blessingSlots[3] != null)
            {
                UpdateBlessingText(blessingSlots[3]);
            }

            nextLevelButton.interactable = true;
            DisableDoor(); // Call function to disable the door
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NPC"))
        {
            playerTalkedToNPC = true;
            questActive = true;

            if (!questItemObtained)
            {
                Debug.Log("Obtain a quest item with the tag 'QuestItem'.");
            }
            else
            {
                Debug.Log("Go back and talk to the NPC.");
            }

            currentLevel = SceneManager.GetActiveScene().name;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("NPC"))
        {
            playerTalkedToNPC = false;
        }
    }

    private void CheckForQuestItem()
    {
        if (GameObject.FindGameObjectWithTag("QuestItem") != null)
        {
            questItemObtained = true;
            Debug.Log("You obtained the quest item. Go back and talk to the NPC.");
        }
    }

    private void UpdateBlessingText(string blessing)
    {
        blessingText.text = blessing;
    }

    private void DisableDoor()
    {
        // Disable the door to the next level
    }

    public void CompleteQuest()
    {
        if (currentLevel == "Tutorial")
        {
            blessingSlots[0] = "Blessing 1";
        }
        else if (currentLevel == "Tunnels")
        {
            blessingSlots[1] = "Blessing 2";
        }
        else if (currentLevel == "Industrial Area")
        {
            blessingSlots[2] = "Blessing 3";
        }
        else if (currentLevel == "Commercial District")
        {
            blessingSlots[3] = "Blessing 4";
        }

        pauseScreen.SetActive(true);
        blessingButton.interactable = true;
        questActive = false;
        questItemObtained = false;
        playerTalkedToNPC = false;
    }

    public void ContinueToNextLevel()
    {
        // Perform the logic to load the next level
        // ...
    }
}
