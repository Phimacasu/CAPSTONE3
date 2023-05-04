using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSwitch : MonoBehaviour
{
    [SerializeField]
    GameObject systemBoss;

    [SerializeField]
    bool stateIsActivated = false, stateHasOneTime;

    [SerializeField]
    Material matOff, matHover, matOn;

    bool stateHasPlayer, stateIsOneTimed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SwitchSystem();
    }

    private void SwitchSystem()
    {
        if (!stateIsOneTimed && stateHasPlayer)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.LogWarning("Button Pressed!");
                stateIsActivated = true;
                systemBoss.GetComponent<BossSpawn>().UpdateBoss();

                gameObject.GetComponent<MeshRenderer>().material = matOn;

                if (stateHasOneTime)
                    stateIsOneTimed = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!stateIsActivated)
            if (other.gameObject.tag == "Player")
            {
                Debug.LogWarning("Can press button.");
                gameObject.GetComponent<MeshRenderer>().material = matHover;
                stateHasPlayer = true;
            }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!stateIsActivated)
            if (other.gameObject.tag == "Player")
            {
                gameObject.GetComponent<MeshRenderer>().material = matOff;
                stateHasPlayer = false;
            }

    }
}
