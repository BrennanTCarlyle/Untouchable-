using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlockBehaviour : MonoBehaviour
{
    [Tooltip("Movement speed")]
    public int minSpeed;
    public int maxSpeed;

    private int speed;

    public int killTimer = 3;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("killSelf", killTimer);
        speed = Random.Range(minSpeed, maxSpeed);
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
