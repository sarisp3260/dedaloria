using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPanel : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

public void Instructions()
    {
        SceneManager.LoadScene("Instructions");
    }

public void Credits()
    {
        SceneManager.LoadScene("CreditsGame");
    }
}
