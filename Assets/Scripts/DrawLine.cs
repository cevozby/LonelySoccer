using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DrawLine : MonoBehaviour
{
    Scene simulationScene;
    PhysicsScene physicsScene;
    [SerializeField] Transform[] obstaclesParents;
    [SerializeField] GameObject[] dummiesParents;

    LineRenderer line;
    [SerializeField] public static int maxPhysicsFrameIterations = 15;
    public int index;
    public int deneme;

    Dictionary<Transform, Transform> dummyObjects = new Dictionary<Transform, Transform>();

    int levelControl = 1;

    Vector3 startPos;

    public bool canShot;


    public int reflection;
    public float maxLength;

    Vector3 direction;

    private void Start()
    {
        index = 0;
        canShot = false;
        startPos = transform.position;
        //CreatePhysicsScene();
        line = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        ChangeScene();
        //SimulateChangesControl();
        deneme = maxPhysicsFrameIterations;
        //DrawingLine();

        if (Input.GetMouseButtonUp(0))
        {
            line.enabled = false;
        }

    }

    #region SceneManagement
    /*public void CreatePhysicsScene()
    {

        simulationScene = SceneManager.CreateScene("SimulationScene" + levelControl, new CreateSceneParameters(LocalPhysicsMode.Physics3D));
        physicsScene = simulationScene.GetPhysicsScene();

        foreach (Transform obj in obstaclesParents[levelControl - 1])
        {
            var ghostObj = Instantiate(obj.gameObject, obj.position, obj.rotation);
            ghostObj.GetComponent<MeshRenderer>().enabled = false;
            SceneManager.MoveGameObjectToScene(ghostObj, simulationScene);
            if (!ghostObj.isStatic)
            {
                dummyObjects.Add(obj, ghostObj.transform);
            }
        }
    }*/

    void ChangeScene()
    {
        if (levelControl != LevelManager.level)
        {
            dummyObjects.Clear();
            dummiesParents[levelControl - 1].SetActive(false);
            //SceneManager.UnloadSceneAsync("SimulationScene" + levelControl);
            levelControl++;
            dummiesParents[levelControl - 1].SetActive(true);
            //CreatePhysicsScene();
            StartCoroutine(ResetBallTimer());

        }
    }

    #endregion

    #region SimulateManagement

    /*public void SimulateDottedLine(Ball ballPrefab, Vector3 pos, Vector3 velocity)
    {
        var ghostBall = Instantiate(ballPrefab, pos, Quaternion.identity);
        //ghostBall.GetComponent<MeshRenderer>().enabled = false;
        SceneManager.MoveGameObjectToScene(ghostBall.gameObject, simulationScene);

        ghostBall.Init(velocity);

        line.positionCount = maxPhysicsFrameIterations;

        for(int i = 0; i < maxPhysicsFrameIterations; i++)
        {
            physicsScene.Simulate(Time.fixedDeltaTime);
            line.SetPosition(i, ghostBall.transform.position);
        }

        Destroy(ghostBall.gameObject);
    }*/

    public void DrawingLine()
    {
        line.enabled = true;
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        line.positionCount = 1;
        line.SetPosition(0, transform.position);

        float remainingLenth = maxLength;

        for(int i = 0; i < reflection; i++)
        {
            if(Physics.Raycast(ray.origin, ray.direction, out hit, remainingLenth))
            {
                line.positionCount++;
                line.SetPosition(line.positionCount - 1, hit.point);
                ray = new Ray(hit.point, Vector3.Reflect(ray.direction, hit.normal));

                if (hit.collider.CompareTag("SoccerGoal"))
                {
                    canShot = true;
                }
                else
                {
                    canShot = false;
                }

                if (!hit.collider.CompareTag("Dummy") && !hit.collider.CompareTag("RedDummy"))
                {
                    break;
                }
                
            }
            else
            {
                line.positionCount++;
                line.SetPosition(line.positionCount - 1, ray.origin + ray.direction * remainingLenth);
            }
        }

    }

    void SimulateChangesControl()
    {
        foreach (var item in dummyObjects)
        {
            item.Value.position = item.Key.position;
            item.Value.rotation = item.Key.rotation;
        }
    }

    #endregion

    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Dummy") || collision.gameObject.CompareTag("RedDummy"))
        {
            Debug.Log("Dummy'e deðdi");
        }
    }*/

    IEnumerator ResetBallTimer()
    {

        yield return new WaitForSeconds(1.5f);
        transform.position = startPos;
        Shoting.shotCheck = false;
        GoalManager.goalCheck = false;
    }

}
