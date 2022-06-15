using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyRotateManager : MonoBehaviour
{
    //Shoting redControl;

    private void Update()
    {
        //Debug.Log("Ignore Mouse: " + Shoting.IgnoreMouse());
        if (Input.GetMouseButtonDown(0))
        {
            RedDummyRotate();
        }
    }
    
    void RedDummyRotate()
    {
        if (Shoting.IgnoreMouse())
        {
            transform.Rotate(Vector3.up * 45);
            Debug.Log("Red Dummy Click");
        }
    }

}
