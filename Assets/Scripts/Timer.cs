using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    Text timerText;
    float timePassed = 0f;
    bool paused = false;

    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!paused)
        {
            timePassed += Time.deltaTime;
            timerText.text = "Time:  " + string.Format("{0}:{1:00}", (int)timePassed / 60, (int)timePassed % 60);

        }

    }
}
