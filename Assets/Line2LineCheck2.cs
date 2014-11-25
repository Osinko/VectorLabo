using UnityEngine;
using System.Collections;

public class Line2LineCheck2 : MonoBehaviour
{
		const float epsilon = 0.00001f;

		public  Vector3 vStart, vEnd, wStart, wEnd;
		public bool crossCheck;

		Vector3 crossPoint;
		Vector3 p1, p2, p3, p4;

		float t1, t2;
		Vector3 newVector, newVector2;
		bool crossNormalCheck, lengthCheck, insideCheck;

		Vector3 cross_vw, cross_common, cross_common2;
		Vector3 incheck, incheck2;

		Vector3 vStartWend, vEndWstart;

		void Update ()
		{
				crossCheck = false;
				insideCheck = false;		
				Vector3 v = vEnd - vStart;
				Vector3 w = wEnd - wStart;
				Vector3 common = vEnd - wEnd;
				Vector3 common2 = vStart - wStart;

				cross_vw = Vector3.Cross (v, w);
				cross_common = Vector3.Cross (common, v);
				cross_common2 = Vector3.Cross (common2, w);

				t1 = cross_common.magnitude / cross_vw.magnitude;
				t2 = cross_common2.magnitude / cross_vw.magnitude;
		
				newVector = w * -t1;
				newVector2 = v * t2;

				crossPoint = newVector + wEnd;	//交点

				//各辺のベクトルと交点に対する外積を取って内側にある確認する
				p1 = Vector3.Cross (vStart - wStart, vStart - crossPoint);
				p2 = Vector3.Cross (wEnd - vStart, wEnd - crossPoint);
				p3 = Vector3.Cross (vEnd - wEnd, vEnd - crossPoint);
				p4 = Vector3.Cross (wStart - vEnd, wStart - crossPoint);

//				incheck = Vector3.Cross (vStartWend, newVector);
//				incheck2 = Vector3.Cross (vStartWend, newVector2);
//				insideCheck = incheck.x * incheck2.x <= 0 && incheck.y * incheck2.y <= 0 && incheck.z * incheck2.z <= 0;

				crossNormalCheck = epsilon > (Vector3.Cross (cross_common, cross_vw)).sqrMagnitude;
				lengthCheck = t1 + epsilon > 0 && t1 - epsilon < 1 && t2 + epsilon > 0 && t2 - epsilon < 1;

				if (crossNormalCheck && lengthCheck) {
						crossCheck = true;
				}

				Debug.DrawLine (vStart, vStart + v, Color.blue);
				Debug.DrawLine (wStart, wStart + w, Color.green);
				Debug.DrawLine (wEnd, newVector + wEnd, Color.red);
				Debug.DrawLine (vStart, newVector2 + vStart, Color.yellow);
				Debug.DrawLine (wEnd, wEnd + common, Color.grey);
				Debug.DrawLine (wStart, wStart + common2, Color.cyan);

				Debug.DrawLine (Vector3.zero, cross_common, Color.cyan);
				Debug.DrawLine (Vector3.zero, cross_common2, Color.yellow);
				Debug.DrawLine (Vector3.zero, cross_vw, Color.red);
	
		}
}
