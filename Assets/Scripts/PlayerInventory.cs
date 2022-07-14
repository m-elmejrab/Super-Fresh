using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{


    public int maxCapacity = 4;

    private List<Fruit> collectedFruits;

    // Start is called before the first frame update
    void Start()
    {
        collectedFruits = new List<Fruit>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collectedFruits.Count < maxCapacity)
        {
            if (collision.transform.CompareTag("Apple"))
            {
                collectedFruits.Add(new Fruit(Fruit.FruitType.Apple));
                Destroy(collision.gameObject);
                SoundManager.instance.PlayCollectFruit();

            }

            if (collision.transform.CompareTag("Banana"))
            {
                collectedFruits.Add(new Fruit(Fruit.FruitType.Banana));
                Destroy(collision.gameObject);
                SoundManager.instance.PlayCollectFruit();

            }

            if (collision.transform.CompareTag("Lemon"))
            {
                collectedFruits.Add(new Fruit(Fruit.FruitType.Lemon));
                Destroy(collision.gameObject);
                SoundManager.instance.PlayCollectFruit();

            }

            if (collision.transform.CompareTag("Pear"))
            {
                collectedFruits.Add(new Fruit(Fruit.FruitType.Pear));
                Destroy(collision.gameObject);
                SoundManager.instance.PlayCollectFruit();

            }

            UIManager.instance.UpdatePlayerInventoryUI(collectedFruits);
        }
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
        if(fruitsToRemove.Count>0)
            SoundManager.instance.PlayDiscardFruit();
    }

}
