using UnityEngine;
using System.Collections;

public class LinePoint2 : MonoBehaviour
{
		public Vector3 lineStart, lineEnd;
		public Vector3 point;
		public bool check;

		void Update ()
		{
				Debug.DrawLine (lineStart, lineEnd, Color.green);
				Debug.DrawLine (lineStart, point, Color.red);
				check = LinePointCheck (lineStart, lineEnd, point);
		}

		Vector3 v, w;
		float vl, wl;
		public  bool LinePointCheck (Vector3 lineStart, Vector3 lineEnd, Vector3 point)
		{
				v = lineEnd - lineStart;
				w = point - lineStart;

				vl = v.sqrMagnitude;
				wl = w.sqrMagnitude;

				bool crossCheck = (0 == Vector3.Cross (v, w).sqrMagnitude);
				bool dotCheck = (0 <= Vector3.Dot (v, w));
				return crossCheck && dotCheck && vl >= wl; 
		}

	
}
