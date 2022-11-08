using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLose : MonoBehaviour
{

    public float restartDelay = 1f;
    public void Win()
    {
        Debug.Log("You Win");
        Invoke("PlayAgain", restartDelay);
    }
    public void Lose()
    {
        Debug.Log("You Lose!");
        Invoke("Restart", restartDelay);
    }

    void Restart()
    {
        SceneManager.LoadScene(2);
    }
    void PlayAgain()
    {
        SceneManager.LoadScene(3);
    }
}

