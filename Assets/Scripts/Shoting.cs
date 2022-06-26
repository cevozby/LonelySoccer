using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Shoting : MonoBehaviour
{
    [SerializeField] DrawLine drawLine;
    [SerializeField] GameObject infoText;

    Rigidbody ballRB;

    public static bool shotCheck, drawLineCheck;

    
    [SerializeField] float angleSpeed;
    float angle;

    [SerializeField] Transform lineCannon;

    [SerializeField] Animator playerAnim;

    bool playerCheck;

    bool canShot;

    // Start is called before the first frame update
    void Start()
    {
        ballRB = GetComponent<Rigidbody>();
        shotCheck = false;
        canShot = false;
    }

    

    // Update is called once per frame
    void Update()
    {
        ShotControl();

        if (!CanShot())
        {
            drawLine.line.enabled = false;
            drawLineCheck = false;
        }

        if (Input.GetMouseButton(0) && !shotCheck && !IgnoreMouse() && CanShot() && !ignoreUI() && !PurpleDummyPatrol.purpleCheck)
        {
            
            drawLine.DrawingLine();
            drawLineCheck = true;
            BallAngelControl();
        }
    }

    //Rotate linecannon to rotate your line
    void BallAngelControl()
    {
        angle += Input.GetAxis("Mouse X") * angleSpeed * Time.deltaTime;//Get mouse input
        angle = Mathf.Clamp(angle, 30, 150);//Clamp mouse value
        lineCannon.localRotation = Quaternion.Euler(angle * Vector3.up);

    }
    //When player click up to the left mouse button, player shoots
    bool ShotControl()
    {
        if (Input.GetMouseButtonUp(0) && !IgnoreMouse() && CanShot() && !ignoreUI() && !PurpleDummyPatrol.purpleCheck)
        {
            
            playerCheck = true;
            canShot = false;
            infoText.SetActive(false);
            playerAnim.SetBool("Shot", playerCheck);
            StartCoroutine(PlayerAnimWait());
        }
        return shotCheck;
    }


    //Send a ray while pressing the mouse
    //Get information from where the ray hits
    //If the ray hits Red Dummy or Purple Dummy, ignore returns true, otherwise returns false
    public static bool IgnoreMouse()
    {

        bool ignore = false;
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0) || Input.GetMouseButtonUp(0))
        {
            Ray mouse = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            bool isHit = Physics.Raycast(mouse, out hit, 500f);
            if (isHit && (hit.collider.CompareTag("RedDummy") || hit.collider.CompareTag("PurpleDummy")))
            {
                ignore = true;
            }
            else
            {
                ignore = false;
            }
        }
        return ignore;
    }

    //If there is a UI element and the mouse is over it, ignore returns true
    public static bool ignoreUI()
    {
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
        pointerEventData.position = Input.mousePosition;

        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEventData, raycastResults);


        for (int i = 0; i < raycastResults.Count; i++)
        {
            if (raycastResults[i].gameObject.GetComponent<IgnoreGameUI>() != null)
            {
                raycastResults.RemoveAt(i);
                i--;
            }
        }
       
        return raycastResults.Count > 0;
    }
    
    //Can player shot or not, if player wants to cancel shot, player clicks up right mouse button
    bool CanShot()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            canShot = true;
        }
        if (Input.GetMouseButtonDown(1))
        {
            canShot = false;
        }
        return canShot;
    }
    
    IEnumerator PlayerAnimWait()
    {
        yield return new WaitForSeconds(1);
        shotCheck = true;
        playerCheck = false;
        playerAnim.SetBool("Shot", playerCheck);
    }


}
