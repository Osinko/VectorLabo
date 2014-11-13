using UnityEngine;
using System.Collections;

public class Cross : MonoBehaviour
{
		Vector3 vecA, vecB, cross, cross2;
	
		void Start ()
		{
				vecA = new Vector3 (1, 0, 0);
				vecB = new Vector3 (0, 1, 0);

				//外積を自前で計算
				cross = new Vector3 (
					vecA.y * vecB.z - vecA.z * vecB.y,
					vecA.z * vecB.x - vecA.x * vecB.z,
					vecA.x * vecB.y - vecA.y * vecB.x);
				
				//unityの関数で計算
				cross2 = Vector3.Cross (vecA, vecB);
		}
	
		void Update ()
		{
				Debug.DrawLine (Vector3.zero, vecA, Color.red);
				Debug.DrawLine (Vector3.zero, vecB, Color.green);
				Debug.DrawLine (Vector3.zero, cross, Color.blue);
		}
}
