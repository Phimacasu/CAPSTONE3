using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : MonoBehaviour
{
    public float followSpeed = 5f;

    private Transform playerTransform;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (playerTransform != null)
        {
            // Calculate the direction towards the player
            Vector3 direction = playerTransform.position - transform.position;

            // Normalize the direction and move towards the player
            Vector3 movement = direction.normalized * followSpeed * Time.deltaTime;
            transform.position += movement;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Disable collision to prevent further interaction
            GetComponent<Collider>().enabled = false;

            // Attach the QuestItem to the player
            transform.parent = playerTransform;
        }
    }
}
