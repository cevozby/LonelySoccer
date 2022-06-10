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
        index = SceneManager.GetActiveScene().buildIndex;
    }

    public void StartButton()
    {
        SceneManager.LoadScene(index + 1);
    }

    public void NextLevelButton()
    {
        SceneManager.LoadScene(index + 1);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(index);
    }

    public void ExitButton()
    {
        Application.Quit();
    }

}
