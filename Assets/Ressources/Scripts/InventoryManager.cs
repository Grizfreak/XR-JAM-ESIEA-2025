using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject itemInSucker = null;

    public bool IsFull()
    {
        return itemInSucker != null;
    }

    public void AddItem(GameObject item)
    {
        itemInSucker = item;
    }

    public GameObject retrieveItem()
    {
        GameObject item = itemInSucker;
        itemInSucker = null;
        return item;
    }
}
