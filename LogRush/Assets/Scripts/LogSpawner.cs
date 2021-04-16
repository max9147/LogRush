using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogSpawner : MonoBehaviour
{
    public GameObject[] logs;

    private int delayStep = 0;
    private float spawnDelay = 1.5f;
    private float maxDelay = 3f;
    private float logSpeed = 0.018f;

    private void Start()
    {
        StartCoroutine("SpawnLog");
    }

    IEnumerator SpawnLog()
    {
        delayStep++;
        if (delayStep == 5)
        {
            delayStep = 0;

            logSpeed += 0.002f;

            if (spawnDelay < maxDelay)
            {
                spawnDelay += 0.05f;
            }
        }

        yield return new WaitForSeconds(spawnDelay);
        Vector3 spawnPos = new Vector3(Random.Range(-0.4f, 0.4f), 1.9f, 0f);
        Instantiate(logs[Random.Range(0, logs.Length)], spawnPos, Quaternion.identity).GetComponent<LogMovement>().SetSpeed(logSpeed);
        StartCoroutine("SpawnLog");
    }

    public float GetSpawnDelay()
    {
        return spawnDelay;
    }
}