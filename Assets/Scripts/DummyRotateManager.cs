using UnityEngine;

public class DummyRotateManager : MonoBehaviour
{

    private void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            RedDummyRotate();
        }
    }
    //When click to the Red Dummy, rotate it 45 degrees
    void RedDummyRotate()
    {
        if (Shoting.IgnoreMouse())
        {
            transform.Rotate(Vector3.up * 45);
        }
    }

}
