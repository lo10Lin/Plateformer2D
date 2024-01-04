using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class clickOnButtonGameOver : MonoBehaviour
{
    public void QuitButton()
    {
        Application.Quit();
    }

    public void ReplayButton()
    {
        SceneManager.LoadScene(1);
    }
}
