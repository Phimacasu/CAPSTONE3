using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawn : MonoBehaviour
{
    [SerializeField] private GameObject boss;

    [SerializeField] private GameObject doorEnd;

    [SerializeField] private GameObject[] subBoss;

    [SerializeField] int istateBoss = -1;

    // Start is called before the first frame update
    void Start()
    {
        //This is where you put the cutscene system.
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateBoss()
    {
        istateBoss++;

        if (istateBoss < 3)
        {
            if (PlayerPrefs.GetInt("Mop") != 2)
                subBoss[istateBoss].SetActive(true);

            boss.GetComponent<Boss>().cdShoot /= 2;
        }
        else
        {
            boss.SetActive(false);
            doorEnd.SetActive(true);
        }
    }
}
