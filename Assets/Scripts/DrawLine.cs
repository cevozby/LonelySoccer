using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DrawLine : MonoBehaviour
{
    Scene simulationScene;
    PhysicsScene physicsScene;
    [SerializeField] Transform obstaclesParent;

    LineRenderer line;
    [SerializeField] int maxPhysicsFrameIterations = 100;

    private void Start()
    {
        CreatePhysicsScene();
        line = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        
    }

    void CreatePhysicsScene()
    {
        simulationScene = SceneManager.CreateScene("SimulationScene", new CreateSceneParameters(LocalPhysicsMode.Physics3D));
        physicsScene = simulationScene.GetPhysicsScene();

        foreach(Transform obj in obstaclesParent)
        {
            var ghostObj = Instantiate(obj.gameObject, obj.position, obj.rotation);
            ghostObj.GetComponent<MeshRenderer>().enabled = false;
            SceneManager.MoveGameObjectToScene(ghostObj, simulationScene);
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

}
