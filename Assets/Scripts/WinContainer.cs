using UnityEngine;
using UnityEngine.UI;

public class WinContainer : MonoBehaviour //Displays win message and stars/score when level is finished
{
    [SerializeField] Text winScoreText;
    [SerializeField] Image firstStar;
    [SerializeField] Image secondStar;
    [SerializeField] Image thirdStar;
    [SerializeField] Sprite emptyStar;
    [SerializeField] Sprite fullStar;

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
