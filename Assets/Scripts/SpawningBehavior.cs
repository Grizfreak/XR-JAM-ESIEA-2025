using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningBehavior : MonoBehaviour
{
    [SerializeField] GameObject[] spawningItems;
    public float timeBetweeneachSpawn;
    public float currentTime;
    public bool canSpawn;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0f;
    }

    private void FixedUpdate()
    {
        if (canSpawn)
        {
            currentTime += Time.deltaTime;
            if (currentTime >= timeBetweeneachSpawn)
            {
                // instantiate a random item
                int randomIndex = Random.Range(0, spawningItems.Length);
                Instantiate(spawningItems[randomIndex], transform.position, Quaternion.identity);
                currentTime = 0f;
            }
        }
    }
    public void CanSpawn(bool canSpawn)
    {
        this.canSpawn = canSpawn;
    }
}
