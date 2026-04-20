using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject soldierPrefab;
    public float SpawnTimeRange;
    public float m_remainingSpawnTimer = 0f;
    public int soldierDie = 0;
    public int soldierSave = 0;
    private float winConditionTimer = 60f;
    public float SpawnDecrement = 0.2f;

    private bool gameEnded = false; // 🔥 prevent multiple calls

    private void Update()
    {
        if (gameEnded) return;

        m_remainingSpawnTimer -= Time.deltaTime;
        if (m_remainingSpawnTimer <= 0f)
        {
            SpawnNote();
            m_remainingSpawnTimer = SpawnTimeRange;
        }

        winConditionTimer -= Time.deltaTime;
        if (winConditionTimer <= 0f)
        {
            CheckWinCond();
            gameEnded = true; // 🔥 stop Update logic after game ends
        }
    }

    void SpawnNote()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-6f, 7f), Random.Range(-3f, 4f), 0f);
        Instantiate(soldierPrefab, spawnPosition, Quaternion.identity);

        if (SpawnTimeRange > 1f)
        {
            SpawnTimeRange -= SpawnDecrement;
        }
    }

    void CheckWinCond()
    {
        if (soldierDie < 3)
        {
            Debug.Log("You Win!");
        }
        else
        {
            Debug.Log("You Lose!");
        }
    }
}