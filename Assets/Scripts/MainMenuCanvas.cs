using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCanvas : MonoBehaviour
{
    public GameObject helpPanel;

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
