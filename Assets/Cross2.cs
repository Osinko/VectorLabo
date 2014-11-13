using UnityEngine;
using System.Collections;

public class Cross2 : MonoBehaviour
{
		Vector2 w, v;
		float cross, theta;
	
		void Start ()
		{
				w = new Vector2 (2, 0);
				v = new Vector2 (4, 4);
				cross = w.x * v.y - v.x * w.y;
				theta = Mathf.Asin (cross / (w.magnitude * v.magnitude)) * Mathf.Rad2Deg;
		}
	
		void Update ()
		{
				Debug.DrawLine (Vector3.zero, w, Color.green);
				Debug.DrawLine (Vector3.zero, v, Color.blue);
		}
}
