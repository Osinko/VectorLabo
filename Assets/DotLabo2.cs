using UnityEngine;
using System.Collections;

public class DotLabo2 : MonoBehaviour
{
		Vector3 vecA, vecB;
		float theta;

		void Start ()
		{
				vecA = new Vector3 (3, 5, 6);
				vecB = new Vector3 (8, 9, 3);
				theta = Mathf.Acos (Vector3.Dot (vecA, vecB) / (vecA.magnitude * vecB.magnitude)) * Mathf.Rad2Deg;
		}
	
		void Update ()
		{
				Debug.DrawLine (Vector3.zero, vecA);
				Debug.DrawLine (Vector3.zero, vecB);
		}
}
