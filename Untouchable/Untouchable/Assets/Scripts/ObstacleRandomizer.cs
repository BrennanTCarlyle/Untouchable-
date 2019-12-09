using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRandomizer : MonoBehaviour
{
    public GameObject[] obstaclePlatforms;
    public GameObject[] obstacles;
    private int[] obstacleTotal;
    public int randomSpawnLimit;
    public bool manualSpawning;
    public int[] manualSpawnClockwise;
    private bool alreadyTriggered;

    private void Start()
    {
        obstacleTotal = new int[obstacles.Length];
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!alreadyTriggered)
        {
            if(other.gameObject.CompareTag("Player"))
            {
                alreadyTriggered = true;
                if (manualSpawning)
                {
                    for (int i = 0; i < manualSpawnClockwise.Length; i++)
                    {
                        obstaclePlatforms[i].GetComponent<SpawnPoint>().SpawnObject
                            (gameObject, obstacles[manualSpawnClockwise[i]]);
                    }
                }
                else
                {
                    for (int i = 0; i < 4; i++)
                    {
                        int chosenNumber = Random.Range(0,obstacles.Length);
                        GameObject chooseObstacle = obstacles[chosenNumber];

                        if (obstacleTotal[chosenNumber] >= randomSpawnLimit)
                        {
                            while(obstacleTotal[chosenNumber] >= randomSpawnLimit)
                            {
                                chosenNumber = Random.Range(0,obstacles.Length);
                                chooseObstacle = obstacles[chosenNumber];
                            }
                        }
                        obstacleTotal[chosenNumber]++;
                        obstaclePlatforms[i].GetComponent<SpawnPoint>().SpawnObject(gameObject, chooseObstacle);
                    }
                }
            }
        }
    }
}
