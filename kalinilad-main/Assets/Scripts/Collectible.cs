using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField]
    bool stateSequencedState = false;

    [SerializeField]
    int numberSequence = -1;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Sequence"))
            if (PlayerPrefs.GetInt("Sequence") >= numberSequence)
                gameObject.SetActive(stateSequencedState);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerPrefs.SetInt("Sequence", numberSequence);
            gameObject.SetActive(false);
        }

    }
}
