using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject objectToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        SpawnObject();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnObject()
    {
        GameObject spawnedObject = Instantiate(objectToSpawn, transform.position, transform.rotation);
        spawnedObject.transform.SetParent(gameObject.transform.parent, false);
    }
}
