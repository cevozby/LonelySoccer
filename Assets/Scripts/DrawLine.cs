using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DrawLine : MonoBehaviour
{
    Scene simulationScene;
    PhysicsScene physicsScene;
    [SerializeField] public Transform[] obstaclesParents;
    [SerializeField] public GameObject[] dummiesParents;

    LineRenderer line;
    [SerializeField] int maxPhysicsFrameIterations = 100;

    [HideInInspector] public Dictionary<Transform, Transform> dummyObjects = new Dictionary<Transform, Transform>();

    [HideInInspector] public int levelControl = 1;

    Vector3 startPos;

    private void Start()
    {
        //Debug.Log("level control: " + levelControl + " level: " + LevelManager.level);
        startPos = transform.position;
        CreatePhysicsScene();
        line = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        ChangeScene();
        foreach (var item in dummyObjects)
        {
            item.Value.position = item.Key.position;
            item.Value.rotation = item.Key.rotation;
        }
    }

    public void CreatePhysicsScene()
    {
        
        simulationScene = SceneManager.CreateScene("SimulationScene" + levelControl, new CreateSceneParameters(LocalPhysicsMode.Physics3D));
        physicsScene = simulationScene.GetPhysicsScene();

        foreach(Transform obj in obstaclesParents[levelControl - 1])
        {
            var ghostObj = Instantiate(obj.gameObject, obj.position, obj.rotation);
            ghostObj.GetComponent<MeshRenderer>().enabled = false;
            SceneManager.MoveGameObjectToScene(ghostObj, simulationScene);
            if (!ghostObj.isStatic)
            {
                dummyObjects.Add(obj, ghostObj.transform);
            }
        }
    }

    public void SimulateDottedLine(Ball ballPrefab, Vector3 pos, Vector3 velocity)
    {
        var ghostBall = Instantiate(ballPrefab, pos, Quaternion.identity);
        ghostBall.GetComponent<MeshRenderer>().enabled = false;
        SceneManager.MoveGameObjectToScene(ghostBall.gameObject, simulationScene);

        ghostBall.Init(velocity);

        line.positionCount = maxPhysicsFrameIterations;

        for(int i = 0; i < maxPhysicsFrameIterations; i++)
        {
            physicsScene.Simulate(Time.fixedDeltaTime);
            line.SetPosition(i, ghostBall.transform.position);
        }

        Destroy(ghostBall.gameObject);
    }

    void ChangeScene()
    {
        if (levelControl != LevelManager.level)
        {
            dummyObjects.Clear();
            dummiesParents[levelControl - 1].SetActive(false);
            SceneManager.UnloadSceneAsync("SimulationScene" + levelControl);
            levelControl++;
            dummiesParents[levelControl - 1].SetActive(true);
            CreatePhysicsScene();
            StartCoroutine(ResetBallTimer());

        }
    }

    IEnumerator ResetBallTimer()
    {

        yield return new WaitForSeconds(1.5f);
        transform.position = startPos;
        Shoting.shotCheck = false;
        GoalManager.goalCheck = false;
    }

}
