using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    int index;

    // Start is called before the first frame update
    void Start()
    {
        //Get active scene index
        index = SceneManager.GetActiveScene().buildIndex;
    }

    //Pass to the next level
    public void StartButton()
    {
        SceneManager.LoadScene(index + 1);
    }

    //Pass to the next level
    public void NextLevelButton()
    {
        SceneManager.LoadScene(index + 1);
    }

    //Load the same level
    public void RestartButton()
    {
        SceneManager.LoadScene(index);
    }

    //Exit the game
    public void ExitButton()
    {
        Application.Quit();
    }

}
