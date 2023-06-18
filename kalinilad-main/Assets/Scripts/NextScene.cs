using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public string keyTag = "Key";
    public int nextSceneIndex;

    private bool hasKey;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Door"))
        {
            if (hasKey)
            {
                SceneManager.LoadScene(nextSceneIndex);
            }
            else
            {
                Debug.Log("You need a key to open this door.");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(keyTag))
        {
            hasKey = true;
            Destroy(other.gameObject);
            Debug.Log("You found a key!");
        }
    }
}
