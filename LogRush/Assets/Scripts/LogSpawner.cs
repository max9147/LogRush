using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogSpawner : MonoBehaviour
{
    public GameObject log;

    private int delayStep = 0;
    private float spawnDelay = 2f;
    private float maxDelay = 5f;
    private float logSpeed = 0.02f;

    private void Start()
    {
        StartCoroutine("SpawnLog");
    }

    IEnumerator SpawnLog()
    {
        delayStep++;
        if (delayStep == 10)
        {
            delayStep = 0;

            logSpeed += 0.002f;

            if (spawnDelay < maxDelay)
            {
                spawnDelay += 0.1f;
            }
        }

        yield return new WaitForSeconds(spawnDelay);
        Vector3 spawnPos = new Vector3(Random.Range(-0.4f, 0.4f), 1.9f, 0f);
        Instantiate(log, spawnPos, Quaternion.identity).GetComponent<LogMovement>().SetSpeed(logSpeed);
        StartCoroutine("SpawnLog");
    }

    public float GetSpawnDelay()
    {
        return spawnDelay;
    }
}