using UnityEngine;
using System.Collections;

//二次の外積と内積
public class CrossDot2D : MonoBehaviour
{
		Vector2 v, w, wNorm;
		float cross, dot;
		Vector2  tesDot;

		//float tesCross;
		Vector2 tesCross;

		void Start ()
		{
				v = new Vector2 (5, 7);
				w = new Vector2 (13, 1);

				wNorm = w.normalized;
				tesDot = Vector2.Dot (v, wNorm) * wNorm;
				tesCross = Vector2Cross (v, wNorm) * Perpendicular (w);
		}

		//二次ベクトルに対して垂直な正規化されたベクトルを返す
		Vector2 Perpendicular (Vector2 vec)
		{
				return  new Vector2 (-vec.y, vec.x).normalized;
		}

		//二次ベクトル用の外積計算関数
		float Vector2Cross (Vector2 lhs, Vector2 rhs)
		{
				return  lhs.x * rhs.y - lhs.y * rhs.x;
		}
	
		void Update ()
		{
				Debug.DrawLine (Vector3.zero, v, Color.white);
				Debug.DrawLine (Vector3.zero, w, Color.white);
				Debug.DrawLine (Vector3.zero, tesDot, Color.green);
				Debug.DrawLine (v, v + tesCross, Color.red);
	
		}
}
