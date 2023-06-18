using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform[] waypoints; // Array of waypoints for patrolling
    public float patrolSpeed = 3f; // Speed at which the enemy patrols
    public float chaseSpeed = 5f; // Speed at which the enemy chases the player
    public float sightRange = 10f; // Range at which the enemy can see the player
    public float attackRange = 2f; // Range at which the enemy attacks the player
    public GameObject bulletPrefab; // Prefab of the bullet object
    public Transform bulletSpawnPoint; // Transform where the bullet spawns

    private Transform target; // Reference to the player's transform
    private int currentWaypointIndex = 0; // Index of the current waypoint
    private bool isChasing = false; // Flag to indicate if the enemy is chasing the player

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, target.position);

        if (distanceToPlayer <= attackRange)
        {
            // Attack the player
            Attack();
        }
        else if (distanceToPlayer <= sightRange)
        {
            // Chase the player
            isChasing = true;
            Chase();
        }
        else
        {
            // Patrol between waypoints
            isChasing = false;
            Patrol();
        }
    }

    private void Patrol()
    {
        // Move towards the current waypoint
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, patrolSpeed * Time.deltaTime);

        // Check if the enemy has reached the current waypoint
        if (transform.position == waypoints[currentWaypointIndex].position)
        {
            // Move to the next waypoint
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
    }

    private void Chase()
    {
        // Move towards the player's position
        transform.position = Vector3.MoveTowards(transform.position, target.position, chaseSpeed * Time.deltaTime);
    }

    private void Attack()
    {
        // Instantiate a bullet prefab at the bullet spawn point
        Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
    }
}

