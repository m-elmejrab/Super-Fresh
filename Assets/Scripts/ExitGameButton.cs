using UnityEngine;

public class ExitGameButton : MonoBehaviour //button handling quit/return to main menu
{
    public void ExitGameClicked()
    {
        SoundManager.instance.PlayUIClick();
        Application.Quit();
    }

    public void ReturnToMainMenu()
    {
        SoundManager.instance.PlayUIClick();
        GameManager.instance.LoadLevel(0);
    }
}
