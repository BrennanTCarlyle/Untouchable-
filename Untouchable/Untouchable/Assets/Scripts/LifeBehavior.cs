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
            Death();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("KillBox"))
        {
            Death();
        }        
    }

    private void Death()
    {
        DeathPanel.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = Cursor.visible;
    }

    public void LoadSceneName(string givenSceneName)
    {
        SceneManager.LoadScene(givenSceneName);
    }
}
