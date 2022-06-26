using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody ballRB;

    [SerializeField] ParticleSystem smokeEffect;

    int index;
    [SerializeField] float speed, lastForce;

    public static float force;

    List<Vector3> ballMovePositions = new List<Vector3>();

    DrawLine ballMove;

    public static bool notGoal; //We throw the ball and check it's goal or not

    public static bool forceCheck;

    // Start is called before the first frame update
    void Start()
    {
        ballRB = GetComponent<Rigidbody>(); //Get ball's Rigidbody
        ballMove = GetComponent<DrawLine>(); //Get DrawLine script for use some values
        index = 1; //Index start 1 because we add transform position to the first element of the list
        force = 5f;
        notGoal = false;
        
    }

    private void FixedUpdate()
    {
        if (Shoting.shotCheck)
        {
            
            BallMoves();
            
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            BallMovePos();
            
        }
        if (Shoting.shotCheck)
        {
            BallBounce();
            BallLastMove();
        }

    }

    //If player shots then we add line drag positon to the list
    //And ball moves between the list members
    //If ball approach to target, we set the target to next list member and then increase index value
    void BallMoves()
    {
        if (Shoting.shotCheck && index < ballMovePositions.Count)
        {
            
            Vector3 targetPos = new Vector3(ballMovePositions[index].x, transform.position.y, ballMovePositions[index].z);
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.fixedDeltaTime);
            if (Vector3.Distance(transform.position, ballMovePositions[index]) <= 0.2f)
            {
                index++;
            }
            
        }
    }

    //When player shots, give up force for bouncing ball effect
    void BallBounce()
    {
        if(Shoting.shotCheck && !forceCheck)
        {
            
            ballRB.AddForce(Vector3.up * force, ForceMode.Impulse);
            forceCheck = true;
            
        }
    }

    //Firstly we delete all the element in the list and reset to the index value
    //If the element to be added except the first element is not the same as the previous element
    //add the element to the list
    void BallMovePos()
    {
        if(ballMovePositions.Count > 0)
        {
            ballMovePositions.Clear();
            index = 1;
        }
        for (int i = 0; i < ballMove.line.positionCount; i++)
        {
            if (i == 0)
            {
                ballMovePositions.Add(ballMove.line.GetPosition(i));
            }
            else if (i > 0 && ballMove.line.GetPosition(i) != ballMove.line.GetPosition(i - 1))
            {
                ballMovePositions.Add(ballMove.line.GetPosition(i));
            }

        }
    }
    //When ball reach the last element of the list, give it last force to the forward
    //Increase index value so that it doesn't happen again
    void BallLastMove()
    {
        if (index == ballMovePositions.Count && Vector3.Distance(transform.position, ballMovePositions[index - 1]) <= 0.2f)
        {
            ballRB.AddForce(Vector3.right * lastForce, ForceMode.Impulse);
            index++;
            StartCoroutine(GoalControl());
            
        }
    }

    //When ball touch the ground give force to jump and then decrease force
    //If don't decrase force it doesn't look real
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && Shoting.shotCheck)
        {
            if (force >= 0.1f)
            {
                force -= 1f;
                ballRB.AddForce(Vector3.up * force, ForceMode.Impulse);
                smokeEffect.Play();
            }

        }

    }

    //When ball reaches the last point, wait 2 seconds and check it's goal or not
    IEnumerator GoalControl()
    {
        yield return new WaitForSeconds(2);
        if (!GoalManager.goalCheck)
        {
            notGoal = true;
        }
        else
        {
            notGoal = false;
        }
    }

}
