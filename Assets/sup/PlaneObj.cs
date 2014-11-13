using UnityEngine;
using System.Collections;

public class PlaneObj : MonoBehaviour
{
		Transform _norm;

		void Start ()
		{
				_norm = transform.FindChild ("norm").transform;
		}
	
		void Update ()
		{
				Debug.DrawLine (transform.position, _norm.position);
		}
}
