using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoalManager : MonoBehaviour
{
    [SerializeField] ParticleSystem upConfetti;
    [SerializeField] ParticleSystem leftConfetti;
    [SerializeField] ParticleSystem rightConfetti;

    [SerializeField] GameObject goalText;

    [SerializeField] float time;

    public static bool goalCheck;

    // Start is called before the first frame update
    void Start()
    {
        goalCheck = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SoccerGoal"))
        {
            goalCheck = true;
            LevelManager.level++;
            StartCoroutine(ConfettiTimer(time));
        }
    }

    IEnumerator ConfettiTimer(float time)
    {
        upConfetti.Play();
        leftConfetti.Play();
        rightConfetti.Play();
        goalText.SetActive(true);
        yield return new WaitForSeconds(time);
        upConfetti.Stop();
        leftConfetti.Stop();
        rightConfetti.Stop();
        goalText.SetActive(false);
    }

}
