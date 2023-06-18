using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerButton : MonoBehaviour
{
    [SerializeField] private GameObject doorGameObjectA;
    //[SerializeField] private DoorAnims doorAnims;
    //[SerializeField] private DoorHinge doorHinge;

    private IDoor doorA;

    private void Awake()
    {
        doorA = doorGameObjectA.GetComponent<IDoor>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            doorA.OpenDoor();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            doorA.CloseDoor();
        }

        /*if (Input.GetKeyDown(KeyCode.E))
        {
            doorAnims.OpenDoor();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            doorAnims.CloseDoor();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            doorHinge.OpenDoor();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            doorHinge.CloseDoor();
        }*/
    }
}
