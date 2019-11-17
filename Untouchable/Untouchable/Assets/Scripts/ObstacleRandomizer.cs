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
            alreadyTriggered = true;
            if(isRandom)
            {
                if(other.gameObject.CompareTag("Player"))
                {
                    for(int i = 0; i < randomSpawnChance; i++)
                    {
                        obstaclePlatforms[i].GetComponent<SpawnPoint>().SpawnObject
                            (gameObject, obstacles[Random.Range(0,randomSpawnChance)], 0);
                    }
                }
            }
            else
            {
                if(other.gameObject.CompareTag("Player"))
                {
                    for(int i = 0; i < randomSpawnChance; i++)
                    {
                        obstaclePlatforms[i].GetComponent<SpawnPoint>().SpawnObject
                            (gameObject, obstacles[manualSpawnClockwise[i]], 0);
                    }
                }                
            }
        }
    }
}
