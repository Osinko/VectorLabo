using UnityEngine;
using System.Collections;

public class PlaneLabo1 : MonoBehaviour
{
    public Transform _plane;
    public Vector3 p0,p1, v1,normal;

    void Start()
    {
        p0 = new Vector3(0, 2, 0);
        p1 = new Vector3(3, 0, 4);
        v1 = new Vector3(8, 8, 0);
    }

    float PlaneY(Vector3 v1,Vector3 p0,Vector3 p1) {
        return p0.y - (v1.x * (p1.x - p0.x) - v1.z * (p1.z - p0.z)) / v1.y; 
    }

    void Update()
    {
        _plane.position = p0;
        _plane.rotation = Quaternion.FromToRotation(Vector3.up, v1);

        normal = p0 + v1;
        p1.y = PlaneY(v1, p0, p1); 

        Debug.DrawLine(p0, normal, Color.grey);
        Debug.DrawLine(p0, p1, Color.red);
    }
}
