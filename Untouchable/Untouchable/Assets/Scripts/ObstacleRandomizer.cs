using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRandomizer : MonoBehaviour
{
    public GameObject[] obstaclePlatforms;
    public GameObject[] obstacles;
    public bool isRandom;
    public int[] manualSpawnClockwise;
    public int randomSpawnChance;
    private bool alreadyTriggered;

    private void OnTriggerEnter(Collider other)
    {
        if (!alreadyTriggered)
        {
            if(other.gameObject.CompareTag("Player"))
            {
                alreadyTriggered = true;
                if (isRandom)
                {
                    for (int i = 0; i < randomSpawnChance; i++)
                    {
                        obstaclePlatforms[i].GetComponent<SpawnPoint>().SpawnObject
                            (gameObject, obstacles[Random.Range(0,obstacles.Length - 1)]);
                    }
                }
                else
                {
                    for (int i = 0; i < manualSpawnClockwise.Length; i++)
                    {
                        obstaclePlatforms[i].GetComponent<SpawnPoint>().SpawnObject
                            (gameObject, obstacles[manualSpawnClockwise[i]]);
                    }
                }                
            }
        }
    }
}
