using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour //Singleton class responsible for handling UI elements
{
    public static UIManager instance;

    [SerializeField] GameObject winContainer;
    [SerializeField] GameObject leftSideContainer;
    [SerializeField] GameObject rightSideContainer;
    [SerializeField] GameObject pauseMenuContainer;
    [SerializeField] Text scoreText;
    [SerializeField] Sprite pear;
    [SerializeField] Sprite apple;
    [SerializeField] Sprite banana;
    [SerializeField] Sprite lemon;
    [SerializeField] GameObject inventoryContainer;
    [SerializeField] GameObject requestContainer;

    private void Start()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        winContainer.SetActive(false);
        pauseMenuContainer.SetActive(false);
        scoreText.text = "Score: 0";
    }

    public void UpdatePlayerInventoryUI(List<Fruit> collectedFruits)
    {
        foreach (Transform t in inventoryContainer.GetComponentInChildren<Transform>())
        {
            Destroy(t.gameObject);
        }

        int i = 0; //used to place the fruit in correct place
        foreach (Fruit f in collectedFruits)
        {
            switch (f.GetFruitType())
            {
                case Fruit.FruitType.Apple:
                    CreateFruitIcon(apple, new Vector3(100, 0, 0) * i);
                    break;

                case Fruit.FruitType.Pear:
                    CreateFruitIcon(pear, new Vector3(100, 0, 0) * i);
                    break;

                case Fruit.FruitType.Lemon:
                    CreateFruitIcon(lemon, new Vector3(100, 0, 0) * i);
                    break;

                case Fruit.FruitType.Banana:
                    CreateFruitIcon(banana, new Vector3(100, 0, 0) * i);
                    break;

                default:
                    break;
            }

            i++;
        }
    }

    private void CreateFruitIcon(Sprite sprite, Vector3 localPos)
    {
        GameObject o = new GameObject("FruitContainer", typeof(RectTransform));
        o.AddComponent<FruitSelector>();
        BoxCollider2D c = o.AddComponent<BoxCollider2D>();
        SpriteRenderer renderer = o.AddComponent<SpriteRenderer>();
        renderer.sprite = sprite;
        o.transform.SetParent(inventoryContainer.transform);
        o.transform.localPosition = localPos;
        Vector3 size = renderer.sprite.bounds.size;
        c.size = size;
    }

    public void UpdateCustomerRequestText(List<Fruit> reqest)
    {
        foreach (Transform t in requestContainer.GetComponentInChildren<Transform>())
        {
            Destroy(t.gameObject);
        }

        int i = 0;
        foreach (Fruit f in reqest)
        {
            switch (f.GetFruitType())
            {
                case Fruit.FruitType.Apple:
                    CreateRequestedFruitIcon(apple, new Vector3(100, 0, 0) * i);
                    break;

                case Fruit.FruitType.Pear:
                    CreateRequestedFruitIcon(pear, new Vector3(100, 0, 0) * i);
                    break;

                case Fruit.FruitType.Lemon:
                    CreateRequestedFruitIcon(lemon, new Vector3(100, 0, 0) * i);
                    break;

                case Fruit.FruitType.Banana:
                    CreateRequestedFruitIcon(banana, new Vector3(100, 0, 0) * i);
                    break;

                default:
                    break;
            }

            i++;
        }
    }

    private void CreateRequestedFruitIcon(Sprite fruitSprite, Vector3 iconPosition)
    {
        GameObject obj = new GameObject();
        SpriteRenderer renderer = obj.AddComponent<SpriteRenderer>();
        renderer.sprite = fruitSprite;
        obj.transform.parent = requestContainer.transform;
        obj.transform.localPosition = iconPosition;
    }

    public void IncrementScore(int newScore)
    {
        scoreText.text = "Score: " + newScore;
    }

    public void GameEnded(int finalScore, int starsWon)
    {
        leftSideContainer.SetActive(false);
        rightSideContainer.SetActive(false);
        winContainer.SetActive(true);
        winContainer.GetComponent<WinContainer>().ShowWinWindow(finalScore, starsWon);
    }

    public void PauseGame()
    {
        leftSideContainer.SetActive(false);
        rightSideContainer.SetActive(false);
        pauseMenuContainer.SetActive(true);
    }

    public void ResumeGame()
    {
        leftSideContainer.SetActive(true);
        rightSideContainer.SetActive(true);
        pauseMenuContainer.SetActive(false);
    }
}
