using UnityEngine;
using System.Collections;

public class Line2LineCheck3 : MonoBehaviour
{
		const float epsilon = 0.00001f;
	
		public Vector3 vStart, vEnd, wStart, wEnd;
		public	bool crossCheck;
	
		void Update ()
		{
				crossCheck = Line2LineChecker (vStart, vEnd, wStart, wEnd);
		}
		Vector3 p1, p2, p3, p4;
		Vector3 cross_wv;

		bool Line2LineChecker (Vector3 vStart, Vector3 vEnd, Vector3 wStart, Vector3 wEnd)
		{
				Vector3 v, w, c, c2;
				Vector3 cp, cp2;
				bool normalCheck, lengthCheck, insideCheck;

				v = vEnd - vStart;
				w = wEnd - wStart;
				c = vStart - wStart;
				c2 = wEnd - vEnd;

				cross_wv = Vector3.Cross (w, v);
				Vector3 cross_cw = Vector3.Cross (c, w);
				Vector3 cross_c2v = Vector3.Cross (c2, v);

				//法線を利用した平面チェック（ここが偽なら、これ以降の計算は不用なので、本来ここでfalseを返す処理をしても良い）
				normalCheck = epsilon > (Vector3.Cross (cross_cw, cross_wv)).sqrMagnitude;

				float t = cross_cw.magnitude / cross_wv.magnitude;
				float t2 = cross_c2v.magnitude / cross_wv.magnitude;

				cp = t * v + vStart;		//交点
				cp2 = t2 * -w + wEnd;		//交点
				
				//各辺のベクトルと交点に対する外積を取って交点が線同士の内側にあるか確認する
				p1 = Vector3.Cross (vStart - wStart, cp - vStart);
				p2 = Vector3.Cross (wEnd - vStart, cp2 - wEnd);
				p3 = Vector3.Cross (vEnd - wEnd, cp - vEnd);
				p4 = Vector3.Cross (wStart - vEnd, cp2 - wStart);

				bool p1Check = p1.x * cross_wv.x >= 0 && p1.y * cross_wv.y >= 0 && p1.z * cross_wv.z >= 0;
				bool p2Check = p2.x * cross_wv.x >= 0 && p2.y * cross_wv.y >= 0 && p2.z * cross_wv.z >= 0;
				bool p3Check = p3.x * cross_wv.x >= 0 && p3.y * cross_wv.y >= 0 && p3.z * cross_wv.z >= 0;
				bool p4Check = p4.x * cross_wv.x >= 0 && p4.y * cross_wv.y >= 0 && p4.z * cross_wv.z >= 0;

				insideCheck = p1Check && p2Check && p3Check && p4Check;
				lengthCheck = t + epsilon > 0 && t - epsilon < 1 && t2 + epsilon > 0 && t2 - epsilon < 1;

				//確認用コード
				Debug.DrawLine (vEnd, vStart, Color.blue);
				Debug.DrawLine (wEnd, wStart, Color.green);
				Debug.DrawLine (wStart, wStart + c, Color.cyan);
				Debug.DrawLine (vEnd, vEnd + c2, Color.grey);
				Debug.DrawLine (vStart, cp, Color.yellow);
				Debug.DrawLine (wEnd, cp2, Color.red);


				Debug.DrawLine (Vector3.zero, cross_wv, Color.green);
				Debug.DrawLine (Vector3.zero, p1, Color.grey);
				Debug.DrawLine (Vector3.zero, p2, Color.grey);
				Debug.DrawLine (Vector3.zero, p3, Color.grey);
				Debug.DrawLine (Vector3.zero, p4, Color.grey);

				if (normalCheck && lengthCheck && insideCheck) {
						return true;
				}
		
				return false;
		}
}
