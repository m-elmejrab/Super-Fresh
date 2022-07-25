using UnityEngine;

public class MainMenuCanvas : MonoBehaviour //Contains/displays the help info when on main menu
{
    [SerializeField] GameObject helpPanel;

    private void Start()
    {
        HideHelp();
    }

    public void ShowHelp()
    {
        helpPanel.SetActive(true);
    }
    
    public void HideHelp()
    {
        helpPanel.SetActive(false);
    }
}
