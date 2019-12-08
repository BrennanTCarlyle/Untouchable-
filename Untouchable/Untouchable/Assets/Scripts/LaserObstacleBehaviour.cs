using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserObstacleBehaviour : MonoBehaviour
{
    private int randomChance;

    // Start is called before the first frame update
    void Start()
    {
        randomChance = Random.Range(0,2);

        if (randomChance > 0)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
