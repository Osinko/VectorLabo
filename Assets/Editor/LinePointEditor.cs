using UnityEditor;
using UnityEngine;
using System.Collections;

[CustomEditor(typeof(LinePoint)) ]
public class LinePointEditor : Editor
{
		void OnSceneGUI ()
		{
				LinePoint lp = target as LinePoint;
		
				Handles.color = Color.green;
				Handles.DrawLine (lp.dirction, lp.p0);

				Handles.color = Color.red;
				Handles.DrawLine (lp.point, lp.p0);

				//線と点の衝突判定
				//外積によるベクトルの平行チェックなので線は無限となり、その上に点があるかを調べる事になる
				Vector3 vectorDirection = lp.dirction - lp.p0;
				Vector3 vectorPointDirection = lp.point - lp.p0;
				lp.hit = Vector3.Cross (vectorDirection, vectorPointDirection).sqrMagnitude;

				//線分と点で判断する場合はベクトル同士の長さを比べる
				if (lp.hit == 0 && vectorDirection.sqrMagnitude > vectorPointDirection.sqrMagnitude) {
						lp.hitCheck = true;
				} else {
						lp.hitCheck = false;
				}
		}
}
