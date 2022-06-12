using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Rigidbody ballRB;

    // Start is called before the first frame update
    void Start()
    {
        //ballRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init(Vector3 velocity)
    {
        //ballRB.AddForce(velocity, ForceMode.Impulse);
        ballRB.velocity = velocity;
        //transform.Rotate(velocity);
    }

}
