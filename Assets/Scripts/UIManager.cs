using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject winContainer;
    public GameObject leftSideContainer;
    public GameObject rightSideContainer;
    public GameObject pauseMenuContainer;

    public Text scoreText;

    public Sprite pear;
    public Sprite apple;
    public Sprite banana;
    public Sprite lemon;

    public GameObject inventoryContainer;
    public GameObject requestContainer;

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


        int i = 0;
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
                    GameObject o = new GameObject();
                    SpriteRenderer renderer = o.AddComponent<SpriteRenderer>();
                    renderer.sprite = apple;
                    o.transform.parent = requestContainer.transform;
                    o.transform.localPosition = new Vector3(100, 0, 0) * i;
                    break;

                case Fruit.FruitType.Pear:
                    GameObject o1 = new GameObject();
                    SpriteRenderer renderer1 = o1.AddComponent<SpriteRenderer>();
                    renderer1.sprite = pear;
                    o1.transform.parent = requestContainer.transform;
                    o1.transform.localPosition = new Vector3(100, 0, 0) * i;
                    break;

                case Fruit.FruitType.Lemon:
                    GameObject o2 = new GameObject();
                    SpriteRenderer renderer2 = o2.AddComponent<SpriteRenderer>();
                    renderer2.sprite = lemon;
                    o2.transform.parent = requestContainer.transform;
                    o2.transform.localPosition = new Vector3(100, 0, 0) * i;
                    break;

                case Fruit.FruitType.Banana:
                    GameObject o3 = new GameObject();
                    SpriteRenderer renderer3 = o3.AddComponent<SpriteRenderer>();
                    renderer3.sprite = banana;
                    o3.transform.parent = requestContainer.transform;
                    o3.transform.localPosition = new Vector3(100, 0, 0) * i;
                    break;

                default:
                    break;
            }

            i++;

        }
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
