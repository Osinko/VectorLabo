using UnityEngine;
using System.Collections;

public class DotLabo4 : MonoBehaviour
{
		Vector3 v, w;
		float vcosTheta, vsinTheta;
		
		void Start ()
		{
				v = new Vector3 (-3, 3, 0);
				w = new Vector3 (-2, 4, 0);
				//		vcosTheta = Vector2.Dot (v, w / w.magnitude);
				//		vsinTheta = Vector2.Dot (v, Vector2.up);
				vsinTheta = MathfUtils.Vector2Cross (v, w) / w.magnitude;
		}


	
		void Update ()
		{
				Debug.DrawLine (Vector3.zero, v, Color.green);
				Debug.DrawLine (Vector3.zero, w, Color.red);
		}
}

