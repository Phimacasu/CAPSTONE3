using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    Transform spawnPoint;
    Vector3 dirShoot;

    [SerializeField]
    float speedProjVelocity = 0.4f;

    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        spawnPoint = gameObject.transform;
        Setup(player.position);
    }

    public void Setup(Vector3 dirShoot)
    {
        //dirShoot should be the player position
        this.dirShoot = dirShoot;
    }
    // Update is called once per frame
    void Update()
    {
        //transform.position += dirShoot * (speedProjVelocity * Time.deltaTime);
        transform.position -= dirShoot * 0.5f * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
            if (collision.gameObject.name == "Player")
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
