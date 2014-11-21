using UnityEngine;
using System.Collections;

public class ShortLine1 : MonoBehaviour
{
		public Vector3 v, w;
		public Vector3 h;

		void Update ()
		{
				Vector3 wn = w.normalized;
				h = Vector3.Dot (v, wn) * wn; 

				Debug.DrawLine (Vector3.zero, v, Color.blue);
				Debug.DrawLine (Vector3.zero, w, Color.green);
				Debug.DrawLine (v, h, Color.red);
		}
}
