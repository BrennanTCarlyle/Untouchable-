using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlockBehaviour : MonoBehaviour
{
    [Tooltip("Movement speed")]
    public int speed;

    public int killTimer = 3;

    public float startDelay = 1;
    private bool canStart = false;

    [Header("Refs to all moving blocks")]
    public List<GameObject> movingBlocks;

    // Start is called before the first frame update
    void Start()
    {
        canStart = false;
        Invoke("startMoving", startDelay);
        Invoke("killSelf", killTimer);

        // turn off one of three blocks
        movingBlocks[Random.Range(0, 2)].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (canStart)
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
    }

    void startMoving()
    {
        canStart = true;
    }

    void killSelf()
    {
        Destroy(gameObject);
    }
}
