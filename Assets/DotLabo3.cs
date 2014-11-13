using UnityEngine;
using System.Collections;

public class DotLabo3 : MonoBehaviour
{
		Vector3 vecA, vecB, projection;

		void Start ()
		{
				vecA = new Vector3 (3, 2, 4);
				vecB = Vector3.right;
				projection = Vector3.Dot (vecA, vecB) * vecB;
	
		}
	
		void Update ()
		{
				Debug.DrawLine (Vector3.zero, vecA);
				Debug.DrawLine (Vector3.zero, projection);
		}
}
