using UnityEngine;

public class StartGameButton : MonoBehaviour
{
    public int levelToLoadIndex;

    public void LoadFirstLevel()
    {
        SoundManager.instance.PlayUIClick();
        GameManager.instance.LoadLevel(1);
    }

    //Same button script is used for loading different levels aside from the first one
    public void LoadLeveWithIndex()
    {
        SoundManager.instance.PlayUIClick();
        GameManager.instance.LoadLevel(levelToLoadIndex);
    }

    public void ResumeLevelPressed()
    {
        SoundManager.instance.PlayUIClick();
        GameManager.instance.ResumeLevel();
    }

    
}
