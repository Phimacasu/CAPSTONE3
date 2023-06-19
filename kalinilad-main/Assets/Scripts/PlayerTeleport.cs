using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTeleport : MonoBehaviour
{
    private GameObject currentTeleporter;
    private bool stateIsExit = false;
    private Door scriptDoor;

    private string targetScene;
    private Vector3 targetSpawn;
    private string targetSpawnScene;

    [SerializeField]
    bool stateCanProgress = true;

    GameObject objTxtFeedback;

    int currentSequence = -1, prerequisiteSequence = -1;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentTeleporter != null)
            {
                if (currentTeleporter.GetComponent<Teleporter>().GetBossTrigger() == true)
                {
                    currentTeleporter.GetComponent<Teleporter>().ActivateBoss();
                }
                
                transform.position = currentTeleporter.GetComponent<Teleporter>().GetDestination().position;
            }

            if (stateIsExit)
            {
                Progress();
                if(stateCanProgress)
                {
                    if (targetScene != "Tutorial")
                    {
                        Debug.LogWarning("Entered " + targetScene);
                        PlayerPrefs.SetFloat("SpawnX", targetSpawn.x);
                        PlayerPrefs.SetFloat("SpawnY", targetSpawn.y + 1f);
                        PlayerPrefs.SetString("SceneSpawn", targetSpawnScene);
                        PlayerPrefs.DeleteKey("Checkpoint");
                        SceneManager.LoadScene(targetScene);
                    }
                    else
                    {
                        PlayerPrefs.DeleteKey("SpawnX");
                        PlayerPrefs.DeleteKey("Sequence");
                        PlayerPrefs.DeleteKey("Checkpoint");
                        PlayerPrefs.DeleteKey("Net");
                        PlayerPrefs.DeleteKey("Lighter");
                        PlayerPrefs.DeleteKey("Box");
                        PlayerPrefs.DeleteKey("Mop");
                        PlayerPrefs.SetString("SceneSpawn", "Tutorial");
                        SceneManager.LoadScene("Tutorial");
                    }
                    
                }
            }
                
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Teleporter"))
        {
            currentTeleporter = collision.gameObject;
        }

        if(collision.CompareTag("Exit"))
        {
            stateIsExit = true;
            scriptDoor = collision.gameObject.GetComponent<Door>();

            if (targetScene == null || targetScene == "")
            {
                targetScene = scriptDoor.targetScene;
                targetSpawn = scriptDoor.targetSpawn;
                targetSpawnScene = scriptDoor.targetSpawnScene;
                prerequisiteSequence = scriptDoor.numberSequence;
                if (scriptDoor.objTxtFeedback != null)
                    objTxtFeedback = scriptDoor.objTxtFeedback;
            }
                
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            if (collision.gameObject == currentTeleporter)
            {
                currentTeleporter = null;
            }
        }

        if (collision.CompareTag("Exit"))
        {
            if (stateIsExit)
                stateIsExit = false;

            if (targetScene != null)
                targetScene = null;
        }
    }

    private void Progress()
    {
        if (!PlayerPrefs.HasKey("Sequence"))
        {
            stateCanProgress = true;
            PlayerPrefs.SetInt("Sequence", 1);
            return;
        }

        currentSequence = PlayerPrefs.GetInt("Sequence");

        if (currentSequence < prerequisiteSequence)
        {
            stateCanProgress = false;

            if (prerequisiteSequence == 2)
            {
                Debug.LogError("You're missing a Gas Mask!");
                if (objTxtFeedback != null)
                {
                    objTxtFeedback.SetActive(true);
                    Debug.LogWarning("Called");
                }
                    

            }
                

        }
        else
        {
            stateCanProgress = true;
        }
    }
}
