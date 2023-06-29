using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField]
    Material matActive, matOff;
  
    [SerializeField]
    int numCheckpoint = -1;

    [SerializeField]
    string targetSpawnScene;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Checkpoint") == numCheckpoint)
            gameObject.GetComponent<SpriteRenderer>().material = matActive;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("Checkpoint") != numCheckpoint)
            gameObject.GetComponent<SpriteRenderer>().material = matOff;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.LogWarning("Checkpoint!");
        PlayerPrefs.SetInt("Checkpoint", numCheckpoint);
        gameObject.GetComponent<SpriteRenderer>().material = matActive;
        
        PlayerPrefs.SetString("SceneSpawn", targetSpawnScene);

        PlayerPrefs.SetFloat("SpawnX", gameObject.transform.position.x);
        PlayerPrefs.SetFloat("SpawnY", gameObject.transform.position.y);
    }
}
