using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public void SpawnObject(GameObject givenParent, GameObject objectToSpawn)
    {
        GameObject spawnedObject = Instantiate(objectToSpawn, transform.position, transform.rotation);
        spawnedObject.transform.SetParent(givenParent.transform, true);
    }
}
