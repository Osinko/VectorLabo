using UnityEngine;
using System.Collections;

public class VectorTest : MonoBehaviour
{
		Vector3 vecA, vecB, vecC;

		void Start ()
		{
				vecA = new Vector3 (1, 5, 0);
				vecB = new Vector3 (3, 2, 0);
				vecC = vecA + vecB;
		}
	
		void Update ()
		{
				Debug.DrawLine (Vector3.zero, vecA, Color.white);
				Debug.DrawLine (Vector3.zero, vecB, Color.red);
				Debug.DrawLine (Vector3.zero, vecC, Color.grey);
		}
}
