using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
   

    GameObject player;

    bool levelCompleted = false;
    bool levelPaused = false;
    private float timeCustomerWasWaiting = 0f;
    private float acceptableCustomerDelay = 20f;
    private int score = 0;

    public int noStarScore = 70;
    public int oneStarScore = 75;
    public int twoStarScore = 80;
    public int threeStarScore = 90;

    float fadingTime;


    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);


        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    private void Update()
    {
        timeCustomerWasWaiting += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Escape) && !levelCompleted)
        {
            if (!levelPaused)
                PauseLevel();
            else
                ResumeLevel();
        }
    }

   
    public void CustomerServed()
    {
        float timeSpentToServe = acceptableCustomerDelay - timeCustomerWasWaiting;
        if (timeSpentToServe < 0)
            timeSpentToServe = 0;

        int scoreIncrease = 10 + ((int)timeSpentToServe );
        score = score +  scoreIncrease;

        timeCustomerWasWaiting = 0f;
        UIManager.instance.IncrementScore(score);
        SoundManager.instance.PlayCustomerServed();


    }

    public void GameWon()
    {
        levelCompleted = true;

        player.GetComponent<PlayerInventory>().enabled = false;
        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<Animator>().SetFloat("Speed", 0);

        SoundManager.instance.PlayLevelComplete();
       
        int starsWon = 0;

        if (score >= oneStarScore && score < twoStarScore)
            starsWon = 1;
        else if (score >= twoStarScore && score < threeStarScore)
            starsWon = 2;
        else if (score >= threeStarScore)
            starsWon = 3;

        UIManager.instance.GameEnded(score, starsWon);

    }

    public void LoadLevel(int index)
    {
        if (Time.timeScale != 1)
            Time.timeScale = 1;
        StartCoroutine(ChangeLevel(index));
    }

    IEnumerator ChangeLevel(int levelIndex)
    {
        fadingTime = GetComponent<FaderScript>().BeginFade(1);
        yield return new WaitForSeconds(fadingTime + 0.5f);
        SceneManager.LoadScene(levelIndex);
    }

    public void PauseLevel()
    {
        if(!levelCompleted)
        {
            Time.timeScale = 0;
            UIManager.instance.PauseGame();
            levelPaused = true;
        }
        
    }

    public void ResumeLevel()
    {
        if(!levelCompleted)
        {
            Time.timeScale =1;
            UIManager.instance.ResumeGame();
            levelPaused = false;

        }

    }

}
