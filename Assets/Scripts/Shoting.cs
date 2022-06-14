using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoting : MonoBehaviour
{
    [SerializeField] DrawLine drawLine;

    [SerializeField] Ball ball;
    [SerializeField] float force = 20;

    public Vector3 lookForce;

    Rigidbody ballRB;

    public static bool shotCheck;

    Vector3 worldPos;
    [SerializeField] float angleSpeed;
    float angle;


    // Start is called before the first frame update
    void Start()
    {
        ballRB = GetComponent<Rigidbody>();
        shotCheck = false;
    }

    // Update is called once per frame
    void Update()
    {
        ShotControl();
        
        if (Input.GetMouseButton(0))
        {
            if (!shotCheck)
            {
                drawLine.SimulateDottedLine(ball, transform.position, transform.forward * force);
            }
            BallAngelControl();
        }

        if (GoalManager.goalCheck)
        {
            Debug.Log("Gol oldu");
            ballRB.velocity = Vector3.zero;
        }
        
    }

    void BallAngelControl()
    {
        
        //Debug.Log(Input.GetAxis("Mouse X"));
        angle += Input.GetAxis("Mouse X") * angleSpeed * Time.deltaTime;
        //transform.Rotate(Vector3.up * angle);
        angle = Mathf.Clamp(angle, 30, 150);
        //transform.localRotation = Quaternion.AngleAxis(angle, Vector3.up);
        transform.localRotation = Quaternion.Euler(angle * Vector3.up);

    }

    void ShotControl()
    {
        if (Input.GetMouseButtonUp(0))
        {
            //var spawned = Instantiate(ball, transform.position, transform.rotation);

            //spawned.Init(transform.forward * force);
            ballRB.velocity = transform.forward * force;
            shotCheck = true;
        }
    }
}
