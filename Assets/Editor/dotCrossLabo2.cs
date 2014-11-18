using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Line))]
public class dotCrossLabo2 : Editor
{
		void OnSceneGUI ()
		{
				Line line = target as Line;
				Handles.color = Color.white;
				Handles.DrawDottedLine (Vector3.zero, line.n, 5);
				Handles.color = Color.cyan;
				Handles.DrawLine (Vector3.zero, line.p);
				Handles.color = Color.green;
				Handles.DrawLine (Vector3.zero, line.q);

				Handles.color = Color.cyan;
				line.np = line.n.normalized * Vector3.Dot (line.p, line.n.normalized);
				Handles.DrawAAPolyLine (16, Vector3.zero, line.np);
				Handles.DrawWireDisc (line.np, line.n, (line.np - line.p).magnitude);

				Handles.color = Color.green;
				line.nq = line.n.normalized * Vector3.Dot (line.q, line.n.normalized);
				Handles.DrawAAPolyLine (8, Vector3.zero, line.nq);
				Handles.DrawWireDisc (line.nq, line.n, (line.nq - line.q).magnitude);

				//表裏を判定するだけなら正規化は必要ない
				line.d = Vector3.Dot (line.n, line.q - line.p);
		}
}
