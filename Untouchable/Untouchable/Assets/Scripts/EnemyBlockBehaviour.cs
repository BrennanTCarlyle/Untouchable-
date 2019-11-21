using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlockBehaviour : MonoBehaviour
{
    [Tooltip("Movement speed")]
    public int speed;

    public int killTimer = 3;

    [Header("Refs to all moving blocks")]
    public List<GameObject> movingBlocks;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("killSelf", killTimer);

        // turn off one of three blocks
        movingBlocks[Random.Range(0, 3)].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * speed);
    }

    void killSelf()
    {
        Destroy(gameObject);
    }
}
