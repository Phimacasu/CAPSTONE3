using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        PlayerPrefs.DeleteKey("SpawnX");
        PlayerPrefs.DeleteKey("Sequence");
        PlayerPrefs.DeleteKey("Checkpoint");
        PlayerPrefs.DeleteKey("Net");
        PlayerPrefs.DeleteKey("Lighter");
        PlayerPrefs.DeleteKey("Box");
        PlayerPrefs.DeleteKey("Mop");
        PlayerPrefs.SetString("SceneSpawn", "Tutorial");
        SceneManager.LoadScene("Tutorial"); //Loads Tutorial
    }

    public void LoadGame()
    {
        if (PlayerPrefs.HasKey("SceneSpawn"))
        {
            if (PlayerPrefs.GetString("SceneSpawn") != SceneManager.GetActiveScene().name)
                SceneManager.LoadScene(PlayerPrefs.GetString("SceneSpawn"));
        }
        else
        {
            SceneManager.LoadScene("Tutorial");
        }
        //SceneManager.LoadScene("SaveFile"); //Loads from the save file from the scene named SaveFile
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void QuitGame()
    {
        Application.Quit(); //Quits the game
    }

}
