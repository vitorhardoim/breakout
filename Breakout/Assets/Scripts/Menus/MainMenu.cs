using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("LevelChooser");
    }

    //Starts a game level according to the passed int argument.
    public void StartLevel(int lvl) {
    	Application.LoadLevel(lvl);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
