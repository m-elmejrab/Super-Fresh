using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSelector : MonoBehaviour //Handles UI selection of fruits to discard
{
    private bool isSelected = false;

    private void OnMouseDown()
    {
        if (!isSelected)
        {
            isSelected = true;
            transform.localPosition += new Vector3(0, 20f, 0);
        }
        else
        {
            isSelected = false;
            transform.localPosition += new Vector3(0, -20f, 0);
        }

    }

    /// <summary>
    /// Removes fruit from selection in inventory
    /// </summary>
    public void DeselectFruit()
    {
        if (isSelected)
        {
            isSelected = false;
            transform.localPosition += new Vector3(0, -50f, 0);
        }

    }

    public bool IsSelected()
    {
        return isSelected;
    }


}
