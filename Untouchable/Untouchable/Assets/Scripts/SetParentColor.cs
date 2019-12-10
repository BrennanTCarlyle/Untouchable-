using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetParentColor : MonoBehaviour
{
    public Material mat;
    public GameObject[] subPlatforms;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.parent.parent.GetComponent<MeshRenderer>().material = mat;
        subPlatforms[Random.Range(0,subPlatforms.Length)].SetActive(true);
        Destroy(gameObject, 10);
    }
}
