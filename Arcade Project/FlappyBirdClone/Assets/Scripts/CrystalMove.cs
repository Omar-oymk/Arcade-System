using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalMove : MonoBehaviour
{
    public DifficultyScript diff;
    [Range(5f, 10f)]
    public float movespeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        diff = GameObject.Find("Difficulty").GetComponent<DifficultyScript>();
        movespeed = diff.levelAdjuster();
    }

    // Update is called once per frame
    void Update()
    {
        // multiply by time.deltatime to make it frame rate independent
        // move left
        transform.position += new Vector3(-movespeed * Time.deltaTime, 0, 0);

        if(transform.position.x <= -3.22f)
        {
            Destroy(gameObject); // destroy the crystal when it goes off screen
        }

    }
}
