using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetParentColor : MonoBehaviour
{
    public Material mat;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(gameObject.transform.parent.parent);
        gameObject.transform.parent.parent.GetComponent<MeshRenderer>().materials[0] = mat;
    }
}
