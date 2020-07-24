using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
        /*
        PlayerData data = SaveSystem.LoadPlayer();
        Player player = GameObject.FindObjectOfType<Player>();
        player.transform.GetChild(0).GetComponent<GooseDisplay>().goose = data.goose;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];

        player.transform.position = position;

        Debug.Log("Data loaded.");
        */
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
