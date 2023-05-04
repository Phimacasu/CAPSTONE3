using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LockedHatch : MonoBehaviour
{
    private PlayerController thePlayer;

    [SerializeField]
    GameObject textKey;

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
            HatchCheck();
    }

    void HatchCheck()
    {
        if (thePlayer.stateHasKey)
        {
            thePlayer.followingKey.gameObject.SetActive(false);
            thePlayer.followingKey = null;
            gameObject.SetActive(false);
        }
        else
        {
            StartCoroutine(KeyHint());
        }
    }

    IEnumerator KeyHint()
    {
        textKey.SetActive(true);
        yield return new WaitForSeconds(3f);
        textKey.SetActive(false);
    }
}
