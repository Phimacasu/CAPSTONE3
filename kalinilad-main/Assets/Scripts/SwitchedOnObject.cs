using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchedOnObject : MonoBehaviour
{
    [SerializeField]
    bool stateSequencedState = false;

    [SerializeField]
    int numberSequence = -1;

    [SerializeField]
    GameObject onObject;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Sequence"))
            if (PlayerPrefs.GetInt("Sequence") >= numberSequence)
                onObject.SetActive(stateSequencedState);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
