using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Transform spawnPoint;
    Vector3 dirShoot;

    [SerializeField]
    float speedProjVelocity = 20f;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = gameObject.transform;
    }

    public void Setup(Vector3 dirShoot)
    {
        this.dirShoot = dirShoot;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += dirShoot * speedProjVelocity * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Enemy")
            if (other.gameObject.tag != "Ladder")
                Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Enemy")
            if (collision.gameObject.tag != "Ladder")
                Destroy(gameObject);
    }
}
