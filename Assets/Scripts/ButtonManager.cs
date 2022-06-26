using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    int index;

    [SerializeField] GameObject isPlayPanel;

    // Start is called before the first frame update
    void Start()
    {
        //Get active scene index
        index = SceneManager.GetActiveScene().buildIndex;
    }

    private void Update()
    {
        
    }

    //Pass to the next level
    public void StartButton()
    {
        SceneManager.LoadScene(index + 1);
    }

    //We added a panel to the game and we close this panel 0.1 seconds after pressing the button
    //The reason we do this is that after clicking the button, the button closes
    //and the shooting system works as soon as we raise our hand from the mouse
    //That's why we add a panel and close it shortly after pressing the button
    //So the functions don't work because the mouse still defines the UI element
    public void PlayLevelButton()
    {
        StartCoroutine(IsPlay());
    }

    //Exit the game
    public void ExitButton()
    {
        Application.Quit();
    }

    IEnumerator IsPlay()
    {
        yield return new WaitForSeconds(0.1f);
        isPlayPanel.SetActive(false);
    }


}
