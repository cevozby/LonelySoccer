using UnityEngine;

public class NextLevel : MonoBehaviour
{
    [SerializeField] GameObject[] dummiesParents;

    int levelControl;//Get current level value

    private void Start()
    {
        levelControl = 1;
    }

    private void Update()
    {
        ChangeScene();
    }

    #region SceneManagement

    //If levelControl value less then level value, close active level and open new level
    void ChangeScene()
    {
        if (levelControl != LevelManager.level)
        {

            dummiesParents[levelControl - 1].SetActive(false);
            levelControl++;
            dummiesParents[levelControl - 1].SetActive(true);

        }
    }

    #endregion
}
