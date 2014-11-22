using UnityEngine;
using System.Collections;

public class Line2LineCheck : MonoBehaviour
{
		public Vector3 vStart, vEnd;
		public Vector3 wStart, wEnd;
		public bool line2LineCheck;

		void Update ()
		{
				line2LineCheck = CheckLine2Line (vStart, vEnd, wStart, wEnd);
		}

		float t;
		Vector3 test;

		public bool CheckLine2Line (Vector3 vStart, Vector3 vEnd, Vector3 wStart, Vector3 wEnd, bool segments=false)
		{
				Vector3 v = vEnd - vStart;
				Vector3 w = wEnd - wStart;
				Vector3 common = wEnd - vEnd;

				Vector3 cross_vw = Vector3.Cross (v, w);
				Vector3 cross_common = Vector3.Cross (common, v);
				bool crossNormalCheck = 0 == (Vector3.Cross (cross_vw, cross_common)).sqrMagnitude;
	
				t = cross_common.magnitude / cross_vw.magnitude;
				test = w * -t;

				//目視確認用
				Debug.DrawLine (vEnd, vEnd + common, Color.grey);
				Debug.DrawLine (Vector3.zero, cross_vw, Color.white);
				Debug.DrawLine (Vector3.zero, cross_common, Color.grey);
				Debug.DrawLine (vStart, vEnd, Color.green);
				Debug.DrawLine (wStart, wEnd, Color.blue);
				Debug.DrawLine (wEnd, wEnd + test, Color.red);
		
				return crossNormalCheck;
		}

}
