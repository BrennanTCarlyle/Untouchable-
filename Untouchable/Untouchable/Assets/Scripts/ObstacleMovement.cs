using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public int speed;
    public bool started;

    void Awake()
    {
        Time.timeScale = 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitToRun());
    }
    
    private IEnumerator WaitToRun()
    {
        yield return new WaitForSeconds
        (GameObject.Find("Main Camera").GetComponent<Animator>().GetCurrentAnimatorClipInfo(0).Length / 1.5f);
        started = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (started)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
    }
}
