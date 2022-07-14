using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryContainer : MonoBehaviour
{
    public List<string> GetSelectedFruits()
    {
        List<string> selectedFruits = new List<string>();
        foreach (Transform t in GetComponentInChildren<Transform>())
        {
            FruitSelector fs = t.GetComponent<FruitSelector>();
            if(fs != null)
            {
                if(fs.IsSelected())
                {
                    selectedFruits.Add(t.GetComponent<SpriteRenderer>().sprite.name);

                }
            }
        }
        return selectedFruits;
    }

}
