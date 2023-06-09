using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float chaseSpeed = 4f;
    public float attackRange = 1f;
    public float attackDamage = 1f;
    public Transform[] waypoints;
    public Transform player;
    public Transform respawnPoint;
    public GameObject playerPrefab;

    private int currentWaypointIndex = 0;
    private bool isChasing = false;
    [SerializeField] private AudioSource moveSFX;

    private void Start()
    {
        // Find the player using the tag
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (isChasing)
        {
            ChasePlayer();
        }
        else
        {
            Patrol();
        }
    }

    private void Patrol()
    {
        if (waypoints.Length == 0)
            return;

        moveSFX.Play();
        Transform currentWaypoint = waypoints[currentWaypointIndex];
        transform.position = Vector2.MoveTowards(transform.position, currentWaypoint.position, moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, currentWaypoint.position) < 0.1f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }

        if (Vector2.Distance(transform.position, player.position) < attackRange)
        {
            isChasing = true;
        }
    }

    private void ChasePlayer()
    {
        moveSFX.Play();
        transform.position = Vector2.MoveTowards(transform.position, player.position, chaseSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, player.position) > attackRange)
        {
            isChasing = false;
        }

        if (Vector2.Distance(transform.position, player.position) < attackRange)
        {
            AttackPlayer();
        }
    }

    private void AttackPlayer()
    {
        // Destroy the player
        Destroy(player.gameObject);

        // Respawn the player at the last checkpoint
        GameObject newPlayer = Instantiate(playerPrefab, respawnPoint.position, Quaternion.identity);
        newPlayer.tag = "Player";
    }
}
