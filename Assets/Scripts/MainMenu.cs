using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void mainGame()
    {
        SceneManager.LoadScene("Level1");
    }
    public void keluarGame()
    {
        Application.Quit();
    }
    public void menuUtama()
    {
        SceneManager.LoadScene("Menu");
    }
}