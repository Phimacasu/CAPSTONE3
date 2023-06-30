using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject portal;
    public GameObject player;
    [SerializeField] private AudioSource teleportSFX;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Player")
        {
            teleportSFX.Play();
            player.transform.position = new Vector3(portal.transform.position.x, portal.transform.position.y, portal.transform.position.z);
        }
    }
}
