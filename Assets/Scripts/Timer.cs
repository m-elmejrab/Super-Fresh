using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour //Displays time on UI
{
    Text timerText;
    float timePassed = 0f;
    bool paused = false;
    void Start()
    {
        timerText = GetComponent<Text>();
    }

    void Update()
    {
        if (!paused)
        {
            timePassed += Time.deltaTime;
            timerText.text = "Time:  " + string.Format("{0}:{1:00}", (int)timePassed / 60, (int)timePassed % 60);
        }
    }
}
