using UnityEngine;
using System.Collections;

public class Line2LineCheck2 : MonoBehaviour
{
		public  Vector3 vStart, vEnd, wStart, wEnd;
		public	bool crossCheck;

		void Update ()
		{
				crossCheck = Line2LineChecker (vStart, vEnd, wStart, wEnd);
		}

		bool Line2LineChecker (Vector3 vStart, Vector3 vEnd, Vector3 wStart, Vector3 wEnd)
		{
				const float epsilon = 0.00001f;

				Vector3 cross_vw, cross_common, cross_common2;
				Vector3 cp, cp2;
				Vector3 p1, p2, p3, p4;
		
				float t1, t2;
				Vector3 newVector, newVector2;
				bool normalCheck, lengthCheck, insideCheck;

				crossCheck = false;
				insideCheck = false;		
				Vector3 v = vEnd - vStart;
				Vector3 w = wEnd - wStart;
				Vector3 c = vEnd - wEnd;
				Vector3 c2 = vStart - wStart;
		
				cross_vw = Vector3.Cross (v, w);
				cross_common = Vector3.Cross (c, v);
				cross_common2 = Vector3.Cross (c2, w);

				//法線チェック（ここが偽なら、これ以降の計算は不用なので、本来ここでfalseを返す処理をしても良い）
				normalCheck = epsilon > (Vector3.Cross (cross_common, cross_vw)).sqrMagnitude;
		
				t1 = cross_common.magnitude / cross_vw.magnitude;
				t2 = cross_common2.magnitude / cross_vw.magnitude;	//!
		
				newVector = w * -t1;
				newVector2 = v * t2;	//
		
				cp = newVector + wEnd;		//交点
				cp2 = newVector2 + vStart;	//交点
		
				//各辺のベクトルと交点に対する外積を取って交点が線同士の内側にあるか確認する
				p1 = Vector3.Cross (vStart - wStart, cp - vStart);
				p2 = Vector3.Cross (wEnd - vStart, cp2 - wEnd);
				p3 = Vector3.Cross (vEnd - wEnd, cp - vEnd);
				p4 = Vector3.Cross (wStart - vEnd, cp2 - wStart);
		
				bool p1Check = p1.x * cross_vw.x <= 0 && p1.y * cross_vw.y <= 0 && p1.z * cross_vw.z <= 0;
				bool p2Check = p2.x * cross_vw.x <= 0 && p2.y * cross_vw.y <= 0 && p2.z * cross_vw.z <= 0;
				bool p3Check = p3.x * cross_vw.x <= 0 && p3.y * cross_vw.y <= 0 && p3.z * cross_vw.z <= 0;
				bool p4Check = p4.x * cross_vw.x <= 0 && p4.y * cross_vw.y <= 0 && p4.z * cross_vw.z <= 0;
		
				insideCheck = p1Check && p2Check && p3Check && p4Check;
				lengthCheck = t1 + epsilon > 0 && t1 - epsilon < 1 && t2 + epsilon > 0 && t2 - epsilon < 1;
	
				//確認用コード
				Debug.DrawLine (vStart, vStart + v, Color.blue);
				Debug.DrawLine (wStart, wStart + w, Color.green);
				Debug.DrawLine (wEnd, newVector + wEnd, Color.red);
				Debug.DrawLine (vStart, newVector2 + vStart, Color.yellow);
				Debug.DrawLine (wEnd, wEnd + c, Color.grey);
				Debug.DrawLine (wStart, wStart + c2, Color.cyan);

				if (normalCheck && lengthCheck && insideCheck) {
						return true;
				}

				return false;
		}
}
