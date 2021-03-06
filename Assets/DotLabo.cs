﻿using UnityEngine;
using System.Collections;

public class DotLabo : MonoBehaviour
{
		Vector3 vecA, vecB;
		float dot, dotCalc;

		void Start ()
		{
				vecA = new Vector3 (3, 5, 6);
				vecB = new Vector3 (8, 9, 3);
				dot = Vector3.Dot (vecA, vecB);
				dotCalc = 3 * 8 + 5 * 9 + 6 * 3;
		}
	
		void Update ()
		{
				Debug.DrawLine (Vector3.zero, vecA);
				Debug.DrawLine (Vector3.zero, vecB);
		}
}
