using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyScript : MonoBehaviour
{
    // to get the score
    public LogicHandler logicHandler;
    // to get the crystal spawner rate of spawn
    public CrystalSpawner crystalSpawner;
    [Range(1, 11)]
    public int difficulty = 1; // Difficulty level, can be adjusted based on score  
    // Start is called before the first frame update
    void Start()
    {
        logicHandler = GameObject.Find("Logic Handler").GetComponent<LogicHandler>();
        crystalSpawner = GameObject.Find("CrystalSpawner").GetComponent<CrystalSpawner>();
        levelAdjuster();
    }

    // Update is called once per frame
    void Update()
    {
        difficultyAdjuster();
        levelAdjuster();
    }

    void difficultyAdjuster()
    {
        if (logicHandler.playerScore >= 5 && logicHandler.playerScore < 10)
        {
            difficulty = 2;
        }
        else if (logicHandler.playerScore >= 10 && logicHandler.playerScore < 15)
        {
            difficulty = 3;
        }
        else if (logicHandler.playerScore >= 15 && logicHandler.playerScore < 20)
        {
            difficulty = 4;
        }
        else if (logicHandler.playerScore >= 20 && logicHandler.playerScore < 25)
        {
            difficulty = 5;
        }
        else if (logicHandler.playerScore >= 25 && logicHandler.playerScore < 30)
        {
            difficulty = 6;
        }
        else if (logicHandler.playerScore >= 35 && logicHandler.playerScore < 40)
        {
            difficulty = 7;
        }
        else if (logicHandler.playerScore >= 40 && logicHandler.playerScore < 45)
        {
            difficulty = 8;
        }
        else if (logicHandler.playerScore >= 50 && logicHandler.playerScore < 55)
        {
            difficulty = 9;
        }
        else if (logicHandler.playerScore >= 55 && logicHandler.playerScore < 60)
        {
            difficulty = 10;
        }
        else if (logicHandler.playerScore >= 60)
        {
            difficulty = 11;
        }
    }

    public float levelAdjuster()
    {
        if (difficulty == 1)
        {
            crystalSpawner.spawnRate = 4f;
            return 1f;

        }
        else if (difficulty == 2)
        {
            crystalSpawner.spawnRate = 3.5f;
            return 1.5f;
        }
        else if (difficulty == 3)
        {
            crystalSpawner.spawnRate = 3f;
            return 2f;
        }
        else if (difficulty == 4)
        {
            crystalSpawner.spawnRate = 2.5f;
            return 2.5f;
        }
        else if (difficulty == 5)
        {
            crystalSpawner.spawnRate = 2f;
            return 3f;
        }
        else if (difficulty == 6)
        {
            crystalSpawner.spawnRate = 1.5f;
            return 3.5f;

        }
        else if (difficulty == 7)
        {
            crystalSpawner.spawnRate = 1f;
            return 4f;
        }
        else if (difficulty == 8)
        {
            crystalSpawner.spawnRate = 1f;
            return 4.5f;
        }
        else if (difficulty == 9)
        {
            crystalSpawner.spawnRate = 1f;
            return 5f;
        }
        else if (difficulty == 10)
        {
            crystalSpawner.spawnRate = 1f;
            return 5.5f;
        }
        else
        {
            crystalSpawner.spawnRate = 1f;
            return 6f;
        }
    }
}
