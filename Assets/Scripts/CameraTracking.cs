using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{
    
    [SerializeField] Transform target;//Get the target information
    [SerializeField] Vector3 offset;//Set distance between camera and the target

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = target.position + offset;//Set camera position 
    }
}
