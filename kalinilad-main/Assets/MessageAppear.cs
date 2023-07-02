using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageAppear : MonoBehaviour
{
    public GameObject Dialogue;
    public GameObject NotifSign;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            NotifSign.SetActive(true);
            Dialogue.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            NotifSign.SetActive(false);
            Dialogue.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
