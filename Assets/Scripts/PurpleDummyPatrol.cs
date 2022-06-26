using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleDummyPatrol : MonoBehaviour
{
    [SerializeField] Vector3 startPos;
    [SerializeField] Vector3 endPos;

    [SerializeField] Transform pointA, pointB;

    Vector3 mouseStartPos;

    bool startCheck, endCheck;

    [SerializeField] float speed;

    Vector3 distance;
    Vector3 slider;

    float zDistance;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        Debug.Log("Point A: " + pointA.position + "Point B: " + pointB.position + "Distance: " + Vector3.Distance(pointA.position, pointB.position));
        zDistance = Camera.main.WorldToScreenPoint(transform.position).z;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //PurplePatrol();
    }

    private void Update()
    {
        //PurpleSlide();
    }

    void PurplePatrol()
    {
        /*if (Vector3.Distance(transform.position, startPos) <= 0.2f)
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
        }*/
        //
    }


    /*void PurpleSlide()
    {
        Vector3 mousePos;
        Vector3 deneme;
        float yStart;
        float yCurrent;
        if (Input.GetMouseButtonDown(0))
        {
            deneme = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            yStart = deneme.y;
            Debug.Log("Start y: " + yStart);
        }
        
        if (Input.GetMouseButton(0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            yCurrent = mousePos.y;
            Debug.Log(" current y: " + yCurrent);
        }
        Ray mouse = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Debug.Log(mouse);
        RaycastHit hit;
        bool isHit = Physics.Raycast(mouse, out hit, 500f);

        if (isHit && hit.collider.CompareTag("PurpleDummy"))
        {
            
            
        }
    }*/

    private void OnMouseDown()
    {
        //distance = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDrag()
    {
        /*slider = new Vector3(Input.mousePosition.x, Input.mousePosition.y, zDistance);
        slider.x = Mathf.Clamp(slider.x, pointA.position.x, pointB.position.x);
        slider.y = Mathf.Clamp(slider.y, pointA.position.y, pointB.position.y);
        slider.z = Mathf.Clamp(slider.z, pointA.position.z, pointB.position.z);
        

        transform.position = slider; //Camera.main.ScreenToWorldPoint(Input.mousePosition - distance);
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(slider);
        float xClamp = Mathf.Clamp(worldPosition.x, pointA.position.x, pointB.position.x);
        float yClamp = Mathf.Clamp(worldPosition.y, transform.position.y, transform.position.y);
        float zClamp = Mathf.Clamp(worldPosition.z, pointA.position.z, pointB.position.z);

        transform.position = new Vector3(xClamp, yClamp, zClamp);*/
        float distancee = Vector3.Distance(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
        Debug.Log("Distance: " + distancee);
        if(distancee >= 7f)
        {
            transform.Translate(transform.right * speed * distancee/10);
        }
        


    }

}
