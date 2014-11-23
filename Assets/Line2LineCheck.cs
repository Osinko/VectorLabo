using UnityEngine;
using System.Collections;

public class Line2LineCheck : MonoBehaviour
{
		const float epsilon = 0.00001f;

		public Vector3 vStart, vEnd;
		public Vector3 wStart, wEnd;
		public bool line2LineCheck;

		void Update ()
		{
				line2LineCheck = CheckLine2Line (vStart, vEnd, wStart, wEnd);
		}

		float t1, t2;
		Vector3 hit1, hit2;

		public bool CheckLine2Line (Vector3 vStart, Vector3 vEnd, Vector3 wStart, Vector3 wEnd)
		{
				Vector3 v = vEnd - vStart;
				Vector3 w = wEnd - wStart;
				Vector3 common = wEnd - vEnd;
				Vector3 common2 = vEnd - wEnd;

				Vector3 cross_vw = Vector3.Cross (v, w);
				Vector3 cross_common = Vector3.Cross (common, v);
				Vector3 cross_common2 = Vector3.Cross (common2, w);
				bool crossNormalCheck = 0 == (Vector3.Cross (cross_vw, cross_common)).sqrMagnitude;
				bool crossDotCheck = 0 > Vector3.Dot (cross_vw, cross_common);

				t1 = cross_common.magnitude / cross_vw.magnitude;
				t2 = cross_common2.magnitude / cross_vw.magnitude;

				bool retCode = false;
				if (crossNormalCheck && crossDotCheck && t1 + epsilon > 0 && t1 - epsilon < 1 && t2 + epsilon > 0 && t2 - epsilon < 1) {
						retCode = true;
				}

				//目視確認用
				hit1 = w * -t1;
				hit2 = v * -t2;
				Vector3 drawShift = new Vector3 (0.02f, 0.02f, 0.02f);
				Debug.DrawLine (vEnd, vEnd + common, Color.grey);
				Debug.DrawLine (Vector3.zero, cross_vw, Color.white);
				Debug.DrawLine (Vector3.zero, cross_common, Color.grey);
				Debug.DrawLine (vStart + drawShift, vEnd + drawShift, Color.green);
				Debug.DrawLine (wStart + drawShift, wEnd + drawShift, Color.blue);
				Debug.DrawLine (wEnd, wEnd + hit1, Color.red);
				Debug.DrawLine (vEnd, vEnd + hit2, Color.cyan);
		
				return retCode;
		}

}
