using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToWinScreen : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // If player collides with the platform, they are allowed to jump again.
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("EndScene");
        }
    }
}
