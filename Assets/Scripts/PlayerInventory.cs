using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int maxCapacity = 4;
    private List<Fruit> collectedFruits;

    void Start()
    {
        collectedFruits = new List<Fruit>();
    }


    private void OnCollisionEnter(Collision collision) //when colliding with a fruit, handle the interaction
    {
        if (collectedFruits.Count < maxCapacity) //checks if inventory has space
        {
            if (collision.transform.CompareTag("Apple"))
            {
                CollectFruit(collision.gameObject, Fruit.FruitType.Apple);
            }

            if (collision.transform.CompareTag("Banana"))
            {
                CollectFruit(collision.gameObject, Fruit.FruitType.Banana);
            }

            if (collision.transform.CompareTag("Lemon"))
            {
                CollectFruit(collision.gameObject, Fruit.FruitType.Lemon);
            }

            if (collision.transform.CompareTag("Pear"))
            {
                CollectFruit(collision.gameObject, Fruit.FruitType.Pear);
            }

            UIManager.instance.UpdatePlayerInventoryUI(collectedFruits);
        }
    }

    private void CollectFruit(GameObject fruitObject, Fruit.FruitType type)
    {
        collectedFruits.Add(new Fruit(type));
        Destroy(fruitObject);
        SoundManager.instance.PlayCollectFruit();
    }

    public bool InventoryHasAllRequestItems(List<Fruit> request)
    {
        List<Fruit> tempInventory = new List<Fruit>(collectedFruits);
        List<Fruit> fruitFound = new List<Fruit>();

        foreach (Fruit f in request)
        {
            foreach (Fruit i in tempInventory)
            {
                if (i.GetFruitTypeString() == f.GetFruitTypeString())
                {
                    fruitFound.Add(f);
                    tempInventory.Remove(i);
                    break;
                }
            }
        }
        return (fruitFound.Count == request.Count);
    }

    public void FinishRequest(List<Fruit> request)
    {
        foreach (Fruit f in request)
        {
            foreach (Fruit i in collectedFruits)
            {
                if (i.GetFruitTypeString() == f.GetFruitTypeString())
                {
                    collectedFruits.Remove(i);
                    break;
                }
            }
        }
        UIManager.instance.UpdatePlayerInventoryUI(collectedFruits);
    }

    public void ClearInventory(List<string> fruitsToRemove)
    {
        foreach (string f in fruitsToRemove)
        {
            foreach (Fruit i in collectedFruits)
            {
                if (i.GetFruitTypeString() == f)
                {
                    collectedFruits.Remove(i);
                    break;
                }
            }
        }

        UIManager.instance.UpdatePlayerInventoryUI(collectedFruits);
        if (fruitsToRemove.Count > 0)
            SoundManager.instance.PlayDiscardFruit();
    }
}
