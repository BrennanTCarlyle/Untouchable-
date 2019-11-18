using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public void SpawnObject(GameObject givenParent, GameObject objectToSpawn, float height)
    {
        GameObject spawnedObject = Instantiate(objectToSpawn, new Vector3(
        transform.position.x, transform.position.y + height, transform.position.z), transform.rotation);
        spawnedObject.transform.SetParent(givenParent.transform, true);
    }
}
