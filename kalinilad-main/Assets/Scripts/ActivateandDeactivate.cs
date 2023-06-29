using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateandDeactivate : MonoBehaviour
{
    [SerializeField]
    GameObject[] objSwitchReliant;

    [SerializeField]
    bool stateIsActivated = false, stateHasOneTime, stateIsSequential = false;

    [SerializeField]
    Material matOff, matHover, matOn;

    bool stateHasPlayer, stateIsOneTimed = false, stateIsSequenced = false;

    [SerializeField]
    int numberSequence = -1;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Sequence"))
            if (PlayerPrefs.GetInt("Sequence") >= numberSequence)
            {
                stateIsSequenced = true;
                gameObject.GetComponent<MeshRenderer>().material = matOn;
            }          
    }

    // Update is called once per frame
    void Update()
    {
        SwitchSystem();
    }

    private void SwitchSystem()
    {
        if (!stateIsOneTimed && stateHasPlayer && !stateIsSequenced)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                for (int i = 0; i < objSwitchReliant.Length; i++)
                {
                    if (!stateIsActivated)
                    {
                        if (objSwitchReliant[i] != null)
                            if (objSwitchReliant[i].activeSelf)
                                objSwitchReliant[i].SetActive(false);
                            else
                                objSwitchReliant[i].SetActive(true);  
                    }
                }
                    
                if (stateIsSequential)
                {
                    Debug.LogWarning("Button Pressed!");
                    stateIsActivated = true;
                    gameObject.GetComponent<MeshRenderer>().material = matOn;
                    PlayerPrefs.SetInt("Sequence", numberSequence);
                }

                if (stateHasOneTime)
                    stateIsOneTimed = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!stateIsSequenced && !stateIsActivated)
            if (other.gameObject.tag == "Player")
            {
                Debug.LogWarning("Can press button.");
                gameObject.GetComponent<MeshRenderer>().material = matHover;
                stateHasPlayer = true;
            }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!stateIsSequenced && !stateIsActivated)
            if (other.gameObject.tag == "Player")
            {
                gameObject.GetComponent<MeshRenderer>().material = matOff;
                stateHasPlayer = false;
            }
            
    }
}
