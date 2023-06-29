using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private Transform destination;
    [SerializeField] private bool isBossTrigger = false;
    [SerializeField] private GameObject boss;

    public Transform GetDestination()
    {
        return destination;
    }

    public bool GetBossTrigger()
    {
        return isBossTrigger;
    }

    public void ActivateBoss()
    {
        if (boss != null)
            boss.SetActive(true);
    }
  
}
