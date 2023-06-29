using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestEnemies : MonoBehaviour
{
    [SerializeField]
    string typeQCollectible;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt(typeQCollectible) == 2)
            gameObject.SetActive(false);
    }
}
