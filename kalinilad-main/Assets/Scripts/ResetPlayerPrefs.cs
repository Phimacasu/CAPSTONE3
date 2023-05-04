using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetPlayerPrefs : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("SceneSpawn"))
        {
            if (PlayerPrefs.GetString("SceneSpawn") == "Tutorial")
            {
                PlayerPrefs.DeleteKey("SpawnX");
                PlayerPrefs.DeleteKey("Sequence");
                PlayerPrefs.DeleteKey("Checkpoint");
                PlayerPrefs.DeleteKey("Net");
                PlayerPrefs.DeleteKey("Lighter");
                PlayerPrefs.DeleteKey("Box");
                PlayerPrefs.DeleteKey("Mop");
                PlayerPrefs.SetString("SceneSpawn", "Tutorial");
            }
            else
                SceneManager.LoadScene(PlayerPrefs.GetString("SceneSpawn"));
        }
        else
        {
            PlayerPrefs.SetString("SceneSpawn", "Tutorial");
            SceneManager.LoadScene("Tutorial");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
