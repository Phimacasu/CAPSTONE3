using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleQuest : MonoBehaviour
{
    [SerializeField]
    string typeQCollectible;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt(typeQCollectible) == 1)
            gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerPrefs.SetInt(typeQCollectible, 1);
            gameObject.SetActive(false);
        }



    }
}
