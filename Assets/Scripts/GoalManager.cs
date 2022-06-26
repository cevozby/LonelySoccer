using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoalManager : MonoBehaviour
{
    //These are particle effects for goal
    [SerializeField] ParticleSystem upConfetti;
    [SerializeField] ParticleSystem leftConfetti;
    [SerializeField] ParticleSystem rightConfetti;

    
    [SerializeField] GameObject goalText;
    [SerializeField] GameObject infoTextObj;

    [SerializeField] TextMeshProUGUI infoText;
    [SerializeField] TextMeshProUGUI dayText;

    [SerializeField] float time;//The time for close effects

    public static bool goalCheck;//Check it's goal

    Vector3 startPos;
    Quaternion startRot;

    [SerializeField] GameObject dayImage;

    Rigidbody ballRB;

    // Start is called before the first frame update
    void Start()
    {
        ballRB = GetComponent<Rigidbody>();
        goalCheck = false;
        startPos = transform.position;//Equal the starting position
        startRot = transform.rotation;//Equal the starting rotation
    }

    // Update is called once per frame
    void Update()
    {
        GameOverReset();
        if(LevelManager.level == 2)
        {
            infoText.text = "Click Red Dummy For Rotate";
        }
        if (LevelManager.level == 3)
        {
            infoText.text = "Slide Purple Dummy With Mouse";
        }
    }

    
    private void OnTriggerEnter(Collider other)
    {
        //When the ball reachs to the soccer goal, play effects and goal animation
        //after close them
        if (other.gameObject.CompareTag("SoccerGoal"))
        {
            goalCheck = true;
            LevelManager.level++;
            StartCoroutine(ConfettiTimer(time));
            StartCoroutine(TextTimer());
            StartCoroutine(ResetBallTimer());
        }
    }
    //If ball doesn't reach to the goal, reset velocity, position, rotation, shot control and goal control
    void GameOverReset()
    {
        if (Ball.notGoal)
        {
            ballRB.velocity = Vector3.zero;
            ballRB.angularVelocity = Vector3.zero;
            transform.position = startPos;
            transform.rotation = startRot;
            infoTextObj.SetActive(true);
            Ball.force = 5f;
            Ball.notGoal = false;
            Shoting.shotCheck = false;
            Ball.forceCheck = false;
            GoalManager.goalCheck = false;
        }
    }

    IEnumerator TextTimer()
    {
        goalText.SetActive(true);
        yield return new WaitForSeconds(2f);
        goalText.SetActive(false);
    }

    IEnumerator ConfettiTimer(float time)
    {
        upConfetti.Play();
        leftConfetti.Play();
        rightConfetti.Play();
        yield return new WaitForSeconds(time);
        upConfetti.Stop();
        leftConfetti.Stop();
        rightConfetti.Stop();
    }
    //If ball reaches to the goal, reset velocity, position, rotation, shot control and goal control
    //Activate Day Image
    IEnumerator ResetBallTimer()
    {

        yield return new WaitForSeconds(2f);
        ballRB.velocity = Vector3.zero;
        ballRB.angularVelocity = Vector3.zero;
        transform.position = startPos;
        transform.rotation = startRot;
        Ball.force = 5f;
        StartCoroutine(DayImageTimer());
        infoTextObj.SetActive(true);
        
        Shoting.shotCheck = false;
        Ball.forceCheck = false;
        GoalManager.goalCheck = false;
    }

    IEnumerator DayImageTimer()
    {
        dayImage.SetActive(true);
        dayText.text = "DAY" + LevelManager.level.ToString();
        yield return new WaitForSeconds(2);
        dayImage.SetActive(false);
    }

}
