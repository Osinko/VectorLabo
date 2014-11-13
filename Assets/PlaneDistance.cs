using UnityEngine;
using System.Collections;

//キャラクタと平面との距離の算出
public class PlaneDistance : MonoBehaviour
{

		Vector3 plane1, plane2, plane3, norm, p1;
		Vector3 d;

		void Start ()
		{
				//キャラクター位置
				p1 = new Vector3 (4, 10, 5);

				//平面		
				plane1 = new Vector3 (0, 5, 10);
				plane2 = new Vector3 (10, 5, 0);
				plane3 = plane1 + plane2;

				//平面に対する法線を外積を利用して求める
				norm = Vector3.Cross (plane1, plane2);
				//正規化された法線
				Vector3 normal = norm.normalized;

				//キャラクターから平面までのベクトル
				d = Vector3.Dot (p1, normal) * normal;
		}
	
		void Update ()
		{
				Debug.DrawLine (Vector3.zero, plane1, Color.white);
				Debug.DrawLine (Vector3.zero, plane2, Color.white);
				Debug.DrawLine (plane1, plane3, Color.white);
				Debug.DrawLine (plane2, plane3, Color.white);

				Debug.DrawLine (Vector3.zero, p1, Color.blue);
				Debug.DrawLine (Vector3.zero, norm, Color.green);
				Debug.DrawLine (Vector3.zero, d, Color.red);
	
		}
}
