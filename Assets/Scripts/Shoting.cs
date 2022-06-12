using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoting : MonoBehaviour
{
    [SerializeField] DrawLine drawLine;

    [SerializeField] Ball ball;
    [SerializeField] float force = 20;

    public Vector3 lookForce;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShotControl();
        drawLine.SimulateDottedLine(ball, transform.position, transform.forward*force);
        //lookForce = transform.forward;
    }

    void ShotControl()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var spawned = Instantiate(ball, transform.position, transform.rotation);

            spawned.Init(ball.transform.forward * force);
        }
    }
}
