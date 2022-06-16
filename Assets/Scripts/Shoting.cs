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

    [SerializeField] Transform lineCannon;


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
            if (!shotCheck && !IgnoreMouse())
            {
                drawLine.DrawingLine();
            }
            BallAngelControl();
        }

        if (GoalManager.goalCheck)
        {
            ballRB.velocity = Vector3.zero;
        }

        /*if (shotCheck)
        {
            transform.Translate(transform.forward * force * Time.deltaTime);
        }*/
        
    }

    void BallAngelControl()
    {
        
        //Debug.Log(Input.GetAxis("Mouse X"));
        angle += Input.GetAxis("Mouse X") * angleSpeed * Time.deltaTime;
        //transform.Rotate(Vector3.up * angle);
        angle = Mathf.Clamp(angle, 30, 150);
        //transform.localRotation = Quaternion.AngleAxis(angle, Vector3.up);
        drawLine.lineCannon.localRotation = Quaternion.Euler(angle * Vector3.up);

    }

    void ShotControl()
    {
        if (Input.GetMouseButtonUp(0) && !IgnoreMouse())
        {
            //var spawned = Instantiate(ball, transform.position, transform.rotation);

            //spawned.Init(transform.forward * force);
            //drawLine.SimulateDottedLine(ball, transform.position, Vector3.zero);
            //ballRB.velocity = drawLine.lineCannon.forward * force;
            ballRB.AddForce(drawLine.lineCannon.forward * force, ForceMode.Impulse);
            //ball.Init(transform.forward * force);
            //transform.Translate(transform.forward * force * Time.deltaTime);
            shotCheck = true;
        }
    }

    public static bool IgnoreMouse()
    {
        
        bool redDummy = false;
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0) || Input.GetMouseButtonUp(0))
        {
            Ray mouse = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            bool isHit = Physics.Raycast(mouse,out hit, 500f);
            
            if (isHit && hit.collider.CompareTag("RedDummy"))
            {
                redDummy = true;
            }
            else
            {
                redDummy = false;
            }
        }
        return redDummy;
    }

    
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Dummy"))
        {

            //var speed = ballRB.velocity.magnitude;
            //ballRB.velocity = Vector3.Reflect(ballRB.velocity, collision.contacts[0].normal);
            //ballRB.velocity = Vector3.Reflect(drawLine.ray.direction, drawLine.hit.normal);
            //ballRB.velocity = direction * Mathf.Max(speed, 0);
        }

    }

}
