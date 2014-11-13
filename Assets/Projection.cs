using UnityEngine;
using System.Collections;

public class Projection : MonoBehaviour
{
		Vector3 va, vb, v, w;
		Vector3 vaDush, vbDush;
		Vector3 vaDushProj, vbDushProj;

		void Start ()
		{
				va = new Vector3 (8, 10, 0);
				vb = new Vector3 (3, 4, 0);
				w = new Vector3 (15, 5, 0);
				v = va - vb;

				Vector2 wNormal = w.normalized;
				vaDush = Vector3.Dot (va, wNormal) * wNormal;
				vbDush = Vector3.Dot (vb, wNormal) * wNormal;

				vaDushProj = Vector3.Project (va, w);	//Vector3クラスに投影関数がある
				vbDushProj = Vector3.Project (vb, w);
		}

		void Update ()
		{
				Vector3 visibleShif = new Vector3 (0.1f, 0.1f, 0.1f);
				Debug.DrawLine (vaDush + visibleShif, vbDush + visibleShif, Color.white);
				Debug.DrawLine (Vector3.zero, w, Color.blue);
				Debug.DrawLine (va, vb, Color.red);
		}
}
