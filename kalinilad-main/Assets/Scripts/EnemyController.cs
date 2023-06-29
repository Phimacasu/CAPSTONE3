using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float chaseSpeed = 4f;
    public float attackRange = 10f;
    public float attackDamage = 1f;
    public Transform[] waypoints;
    public Transform player;
    public Transform respawnPoint;
    public GameObject playerPrefab;
    public GameObject bulletPrefab;
    public float bulletSpeed = 1000000f;
    public float attackCooldown = 5f;

    private int currentWaypointIndex = 0;
    private bool isChasing = false;

    private void Start()
    {
        playerPrefab = GameObject.FindGameObjectWithTag("Player");
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
        transform.position = Vector2.MoveTowards(transform.position, player.position, chaseSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, player.position) > attackRange)
        {
            isChasing = false;
        }

        if (Vector2.Distance(transform.position, player.position) < attackRange)
        {
            AttackPlayer();

            attackCooldown -= 0.01f;
        }
    }

    private void AttackPlayer()
    {
        ThrownProjectile();

        // Respawn the player at the last checkpoint
        //GameObject newPlayer = Instantiate(playerPrefab, respawnPoint.position, Quaternion.identity);
        //newPlayer.tag = "Player";
    }

    private void ThrownProjectile()
    {
        if (attackCooldown <= 0)
        {
            Vector2 direction = player.transform.position - transform.position;
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
            bulletRigidbody.velocity = direction.normalized * bulletSpeed;
            attackCooldown = 5f;
        }
    }
}

