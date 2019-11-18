using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeBehavior : MonoBehaviour
{
    public GameObject DeathPanel;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("KillBox"))
        {
            DeathPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("KillBox"))
        {
            DeathPanel.SetActive(true);
            Time.timeScale = 0;
        }        
    }

    public void LoadSceneName(string givenSceneName)
    {
        SceneManager.LoadScene(givenSceneName);
    }
}
