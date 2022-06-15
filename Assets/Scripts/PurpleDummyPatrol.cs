using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleDummyPatrol : MonoBehaviour
{
    [SerializeField] Vector3 startPos;
    [SerializeField] Vector3 endPos;

    bool startCheck, endCheck;

    [SerializeField] float speed;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PurplePatrol();
    }

    void PurplePatrol()
    {
        if (Vector3.Distance(transform.position, startPos) <= 0.2f)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPos, speed * Time.fixedDeltaTime);
            startCheck = true;
            endCheck = false;
        }
        if (Vector3.Distance(transform.position, endPos) <= 0.2f)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, speed * Time.fixedDeltaTime);
            startCheck = false;
            endCheck = true;
        }

        if (startCheck)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPos, speed * Time.fixedDeltaTime);
        }
        if (endCheck)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, speed * Time.fixedDeltaTime);
        }
    }

}
