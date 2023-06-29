using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTracker : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Box>() != null)
        {
            if (other.gameObject.GetComponent<Box>().stateIsTheBox)
            {
                if (PlayerPrefs.GetInt("Box") != 2)
                    PlayerPrefs.SetInt("Box", 1);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Box>() != null)
            if (other.gameObject.GetComponent<Box>().stateIsTheBox)
            {
                if (PlayerPrefs.GetInt("Box") != 2)
                    PlayerPrefs.SetInt("Box", 0);
            }
    }
}
