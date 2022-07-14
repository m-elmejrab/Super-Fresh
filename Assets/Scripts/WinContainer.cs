using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinContainer : MonoBehaviour
{

    public Text winScoreText;
    public Image firstStar;
    public Image secondStar;
    public Image thirdStar;
    public Sprite emptyStar;
    public Sprite fullStar;


    public void ShowWinWindow(int score, int numOfStars) //0 = no stars, 1 = 1 star ...etc
    {
        winScoreText.text = "Score: " + score;

        switch (numOfStars)
        {
            case 0:
                firstStar.sprite = emptyStar;
                secondStar.sprite = emptyStar;
                thirdStar.sprite = emptyStar;
                break;
            case 1:
                firstStar.sprite = fullStar;
                secondStar.sprite = emptyStar;
                thirdStar.sprite = emptyStar;
                break;
            case 2:
                firstStar.sprite = fullStar;
                secondStar.sprite = fullStar;
                thirdStar.sprite = emptyStar;
                break;
            case 3:
                firstStar.sprite = fullStar;
                secondStar.sprite = fullStar;
                thirdStar.sprite = fullStar;
                break;

            default:
                break;
        }

    }
}
