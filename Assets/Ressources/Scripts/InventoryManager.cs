using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public GameObject itemInSucker = null;
    public Image icon;
    public static InventoryManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void Start()
    {
        icon.enabled = false;
    }

    public bool IsFull()
    {
        return itemInSucker != null;
    }

    public void AddItem(GameObject item)
    {
        itemInSucker = item;
        icon.enabled = true;
        icon.sprite = item.GetComponent<Trash>().icon;
    }

    public GameObject retrieveItem()
    {
        GameObject item = itemInSucker;
        itemInSucker = null;
        icon.enabled = false;
        return item;
    }

    public void DeleteObject()
    {
        Destroy(itemInSucker);
        itemInSucker = null;
        icon.enabled = false;
    }
}
