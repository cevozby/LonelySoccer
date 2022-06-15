using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NextLevel : MonoBehaviour
{
    /*DrawLine level;

    //[SerializeField] Transform ball;
    Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeScene();
    }

    void ChangeScene()
    {
        if (level.levelControl != LevelManager.level)
        {
            level.dummyObjects.Clear();
            level.dummiesParents[level.levelControl - 1].SetActive(false);
            SceneManager.UnloadSceneAsync("SimulationScene" + level.levelControl);
            level.levelControl++;
            level.dummiesParents[level.levelControl - 1].SetActive(true);
            level.CreatePhysicsScene();

        }
    }

    void ResetBall()
    {
        if (level.levelControl != LevelManager.level)
        {
            StartCoroutine(ResetBallTimer());
        }
    }

    IEnumerator ResetBallTimer()
    {

        yield return new WaitForSeconds(1.5f);
        transform.position = startPos;

    }*/
}
