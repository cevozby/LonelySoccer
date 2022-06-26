using UnityEngine;

public class PurpleDummyPatrol : MonoBehaviour
{
    [SerializeField] float speed;

    public static bool purpleCheck;

    bool timerStart;
    float time = 0.5f;

    // Update is called once per frame
    private void Update()
    {
        PurpleSlide();
    }



    void PurpleSlide()
    {
        Vector3 mousePos;
        Vector3 target;
        

        Ray mouse = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool isHit = Physics.Raycast(mouse, out hit, Mathf.Infinity);
        //Get ray info and if it hits Purple Dummy and player doesn't draw shot line, purple Check is true
        if (isHit && hit.collider.CompareTag("PurpleDummy") && !Shoting.drawLineCheck)
        {
            purpleCheck = true;
        }
        //While in your mouse line, move the Purple Dummy to where the mouse is
        if (Input.GetMouseButton(0) && isHit && hit.collider.CompareTag("Line") && purpleCheck)
        {
            mousePos = hit.point;
            target = new Vector3(mousePos.x, transform.position.y, mousePos.z);
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }
        //Set purplecheck to false 0.5 seconds after releasing the mouse
        //In this way, the shot function does not work when we click up to the mouse
        if (Input.GetMouseButtonUp(0) && purpleCheck)
        {
            time = 0.5f;
            timerStart = true;
            
        }

        if (timerStart)
        {
            
            if (time > 0f)
            {
                time -= Time.deltaTime;
                Debug.Log(time);
            }
            if (time <= 0f)
            {
                purpleCheck = false;
                timerStart = false;
            }
        }
    }

}
