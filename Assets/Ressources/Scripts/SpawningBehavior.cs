using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningBehavior : MonoBehaviour
{
    public static SpawningBehavior instance;
    [SerializeField] GameObject[] spawningItems;
    public float timeBetweeneachSpawn;
    public float currentTime;
    public bool canSpawn;

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
                Instantiate(spawningItems[randomIndex], transform.position, spawningItems[randomIndex].gameObject.transform.rotation);
                currentTime = 0f;
            }
        }
    }
    public void CanSpawn(bool canSpawn)
    {
        this.canSpawn = canSpawn;
    }
}
