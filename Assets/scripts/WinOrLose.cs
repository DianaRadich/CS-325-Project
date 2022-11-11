using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class WinOrLose : MonoBehaviour
{
    private bool gameEnded = false;

    //public AudioSource audioSource;
    //public AudioClip fanfare;

    //public UnityEvent<WinOrLose> OnWin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();
        }
    }
    
    public void WinLevel()
    {
        if (gameEnded==false)
        {
            Debug.Log("You win!");
            //audioSource.PlayOneShot(fanfare);

            gameEnded=true;
            SceneManager.LoadScene("Menu");
        }
    }

    public void LoseLevel()
    {
        if (gameEnded==false)
        {
            Debug.Log("You Lose");
            gameEnded=true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // reset scene
        }
    }
}
