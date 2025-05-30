using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalSpawner : MonoBehaviour
{
    public GameObject crystalPrefab; // Prefab of the crystal to spawn
    public float spawnRate = 1.5f; // Difficulty multiplier
    private float timer = 0;
    private float highestY = 0.62f; // Initial highest Y position
    private float lowestY = -0.62f; // Initial highest Y position
    // Start is called before the first frame update
    void Start()
    {
        spawnObject(); // Spawn the first crystal immediately
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= spawnRate)    // u cannot write == because this is a float decimal time.deltatime and will neveer be equal to exactly 2
        {
            // Instantiate a crystal at a random height within the specified range
            Instantiate(crystalPrefab, new Vector3(transform.position.x,Random.Range(highestY, lowestY), -1), transform.rotation);
            timer = 0;
        }
        else
            timer += Time.deltaTime;

    }

    void spawnObject()
    {
        Instantiate(crystalPrefab, new Vector3(transform.position.x, Random.Range(highestY, lowestY), -1), transform.rotation);
    }
}
