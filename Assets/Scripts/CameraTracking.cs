using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{
    //public static bool shotCheck;
    //[SerializeField] Transform target;
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset;
    public Vector3 takip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        takip = target.position;
        transform.position = target.position + offset;
    }
}
