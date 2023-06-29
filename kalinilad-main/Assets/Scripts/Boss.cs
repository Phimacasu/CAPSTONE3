using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField]
    Transform prefabBullet;

    private Transform player;

    [SerializeField]
    float timeSpawn;

    [SerializeField]
    public float cdShoot;

    [SerializeField]
    float cdSwitchable;

    [SerializeField]
    private int istateSwitchable = -2;

    [SerializeField]
    private GameObject[] switchables;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(timeSpawn);

        istateSwitchable++;
        StartCoroutine(Switch());
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(cdShoot);
        Transform transformBullet = Instantiate(prefabBullet, gameObject.transform.position, Quaternion.identity);
        Vector3 dirShoot = (player.position - gameObject.transform.position).normalized;
        transformBullet.GetComponent<Bullet>().Setup(dirShoot);
        StartCoroutine(Shoot());
    }

    IEnumerator Switch()
    {
        if (istateSwitchable == -1)
        {
            istateSwitchable++;
            switchables[istateSwitchable].SetActive(true);

            yield return new WaitForSeconds(cdSwitchable);
            switchables[istateSwitchable].SetActive(false);

            istateSwitchable++;
        }
        else
        {
            switchables[istateSwitchable].SetActive(true);

            yield return new WaitForSeconds(cdSwitchable);
            switchables[istateSwitchable].SetActive(false);

            istateSwitchable *= -1;
        }

        StartCoroutine(Switch());
    }
}
