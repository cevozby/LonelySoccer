using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Rigidbody ballRB;

    List<GameObject> touchDummies = new List<GameObject>();

    int dummyCount;

    public static int addFrame;

    // Start is called before the first frame update
    void Start()
    {
        //ballRB = GetComponent<Rigidbody>();
        dummyCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        addFrame = touchDummies.Count * 50;
        Debug.Log(addFrame);
    }

    public void Init(Vector3 velocity)
    {
        //ballRB.AddForce(velocity, ForceMode.Impulse);
        ballRB.velocity = velocity;
        //transform.Rotate(velocity);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Dummy") || collision.gameObject.CompareTag("RedDummy"))
        {
            if (dummyCount == 0)
            {
                //Debug.Log("Null bloðuna girdi");
                touchDummies.Add(collision.gameObject);
                //Debug.Log("Liste uzunluðu: " + touchDummies.Count + " Liste eleman adý: " + touchDummies[dummyCount].name);
                dummyCount++;
                addFrame = touchDummies.Count * 50;
                //DrawLine.maxPhysicsFrameIterations += addFrame;
                Debug.Log(addFrame);

            }
            else if (touchDummies[dummyCount - 1] != collision.gameObject)
            {
                //Debug.Log("Ekleme bloðuna girdi");
                touchDummies.Add(collision.gameObject);
                //Debug.Log("Liste uzunluðu: " + touchDummies.Count + "Liste eleman adý: " + touchDummies[dummyCount].name);
                addFrame = touchDummies.Count * 50;
                //DrawLine.maxPhysicsFrameIterations += addFrame;
                Debug.Log(addFrame);
                dummyCount++;
                
            }
            else if (touchDummies[dummyCount - 1] == collision.gameObject)
            {
                Debug.Log("Return bloðuna girdi");
                Debug.Log("Liste uzunluðu: " + touchDummies.Count + "Liste eleman adý: " + touchDummies[dummyCount].name);
                return;
            }
        }
    }

    /*private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Dummy") || collision.gameObject.CompareTag("RedDummy"))
        {
            touchDummies.Remove(collision.gameObject);
            addFrame = 
            DrawLine.maxPhysicsFrameIterations -= addFrame;
            dummyCount--;

        }
    }*/

}
