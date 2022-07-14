using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitGameButton : MonoBehaviour
{
    public void ExitGameClicked()
    {
        SoundManager.instance.PlayUIClick();

        Application.Quit();
        Debug.Log("Application Quit has been called");
    }

    public void ReturnToMainMenu()
    {
        SoundManager.instance.PlayUIClick();

        GameManager.instance.LoadLevel(0);
    }
}
