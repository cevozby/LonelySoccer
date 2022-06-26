using UnityEngine;

public class DrawLine : MonoBehaviour
{
    [HideInInspector] public LineRenderer line;


    [SerializeField] int reflection;
    [SerializeField] float maxLength;


    Ray ray;
    RaycastHit hit;

    public Transform lineCannon;

    

    private void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            line.enabled = false;
        }
    }

    

    #region LineManagement

    public void DrawingLine()
    {
        line.enabled = true;
        ray = new Ray(lineCannon.position, lineCannon.forward);
        line.positionCount = 1;
        line.SetPosition(0, lineCannon.position);

        float remainingLenth = maxLength;

        for(int i = 0; i < reflection; i++)
        {
            if(Physics.Raycast(ray.origin, ray.direction, out hit, remainingLenth))
            {
                line.positionCount++;
                line.SetPosition(line.positionCount - 1, hit.point);
                ray = new Ray(hit.point, Vector3.Reflect(ray.direction, hit.normal));
                

                if (!hit.collider.CompareTag("Dummy") && !hit.collider.CompareTag("RedDummy") && !hit.collider.CompareTag("PurpleDummy"))
                {
                    break;
                }
                
            }
            else
            {
                line.positionCount++;
                line.SetPosition(line.positionCount - 1, ray.origin + ray.direction * remainingLenth);
            }
        }

    }


    #endregion

}
