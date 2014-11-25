using UnityEngine;
using System.Collections;

public class Line2LineCheck2 : MonoBehaviour
{
		const float epsilon = 0.00001f;

		public  Vector3 vStart, vEnd, wStart, wEnd;
		public bool crossCheck;

		Vector3 crossPoint, crossPoint2;
		Vector3 p1, p2, p3, p4;
	
		float t1, t2;
		Vector3 newVector, newVector2;
		bool crossNormalCheck, lengthCheck, insideCheck;

		Vector3 cross_vw, cross_common, cross_common2;

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
				crossPoint2 = newVector2 + vStart;	//交点

				//各辺のベクトルと交点に対する外積を取って交点が線同士の内側にあるか確認する
				p1 = Vector3.Cross (vStart - wStart, crossPoint - vStart);
				p2 = Vector3.Cross (wEnd - vStart, crossPoint2 - wEnd);
				p3 = Vector3.Cross (vEnd - wEnd, crossPoint - vEnd);
				p4 = Vector3.Cross (wStart - vEnd, crossPoint2 - wStart);

				bool p1Check = p1.x * cross_vw.x <= 0 && p1.y * cross_vw.y <= 0 && p1.z * cross_vw.z <= 0;
				bool p2Check = p2.x * cross_vw.x <= 0 && p2.y * cross_vw.y <= 0 && p2.z * cross_vw.z <= 0;
				bool p3Check = p3.x * cross_vw.x <= 0 && p3.y * cross_vw.y <= 0 && p3.z * cross_vw.z <= 0;
				bool p4Check = p4.x * cross_vw.x <= 0 && p4.y * cross_vw.y <= 0 && p4.z * cross_vw.z <= 0;

				insideCheck = p1Check && p2Check && p3Check && p4Check;

				crossNormalCheck = epsilon > (Vector3.Cross (cross_common, cross_vw)).sqrMagnitude;
				lengthCheck = t1 + epsilon > 0 && t1 - epsilon < 1 && t2 + epsilon > 0 && t2 - epsilon < 1;

				if (crossNormalCheck && lengthCheck && insideCheck) {
						crossCheck = true;
				}

				//確認用コード
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
