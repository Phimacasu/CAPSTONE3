using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private bool isFollowing;

    public float followSpeed;

    public Transform followTarget;

    PlayerController thePlayer;


    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isFollowing)
        {
            transform.position = Vector3.Lerp(transform.position, followTarget.position, followSpeed * Time.deltaTime);
        }   
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
        {
             if(!isFollowing)
            {
                followTarget = thePlayer.keyFollowPoint;

                isFollowing = true;
                thePlayer.stateHasKey = true;
                thePlayer.followingKey = this; 
            }
        }
    }
}