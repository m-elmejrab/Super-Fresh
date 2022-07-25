using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TreeFruitSpawnController : MonoBehaviour //controls how much fruits do trees spawn and when
{
    [SerializeField] GameObject fruitPrefab;
    [SerializeField] float timeUntilFruitFall = 6f;
    private float timeSinceLastFruitFall = 0f;
    private List<Transform> spawnPoints;
    private List<GameObject> hangingFruits;
    private Vector3 lastFruitPosition;

    void Start()
    {
        //Initialize lists and fill in their data
        spawnPoints = new List<Transform>();
        hangingFruits = new List<GameObject>();
        List<Transform> children = GetComponentsInChildren<Transform>().ToList<Transform>();

        foreach (Transform t in children)
        {
            if (t.CompareTag("FruitSpawnPoint"))
                spawnPoints.Add(t);
        }

        foreach (Transform p in spawnPoints)
        {
            CreateFruit(p.position);
        }

    }

    void FixedUpdate()
    {
        timeSinceLastFruitFall += Time.fixedDeltaTime;

        if (timeSinceLastFruitFall >= timeUntilFruitFall)
        {
            timeSinceLastFruitFall = 0f;
            timeUntilFruitFall += 3f;
            int randomFruitIndex = Random.Range(0, (int)hangingFruits.Count - 1);
            DropFruit(randomFruitIndex);
            StartCoroutine(DelayFruitCreation(0.75f));
        }
    }

    private void DropFruit(int fruitIndex)
    {
        lastFruitPosition = hangingFruits[fruitIndex].transform.position;
        hangingFruits[fruitIndex].GetComponent<Rigidbody>().isKinematic = false;
        float randomForce = Random.Range(0f, 1f);
        Vector3 force = new Vector3(0, 0, randomForce);
        hangingFruits[fruitIndex].GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
        hangingFruits.RemoveAt(fruitIndex);
    }

    private void CreateFruit(Vector3 spawnPosition)
    {
        GameObject fruit = Instantiate(fruitPrefab, spawnPosition, fruitPrefab.transform.rotation);
        fruit.AddComponent<Rigidbody>();
        fruit.GetComponent<Rigidbody>().isKinematic = true;
        fruit.GetComponent<Rigidbody>().angularDrag = 1000f;
        fruit.GetComponent<Rigidbody>().drag = 0.5f;
        hangingFruits.Add(fruit);
    }

    IEnumerator DelayFruitCreation(float delay)
    {
        float percent = 0;
        while (percent < 1)
        {
            percent += Time.deltaTime / delay;
            yield return null;
        }

        CreateFruit(lastFruitPosition);
    }
}
