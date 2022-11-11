using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_select : MonoBehaviour
{
    public int level;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    public void OpenScene() 
    {
        SceneManager.LoadScene("Level " + level.ToString());
    }
}
