using UnityEngine;
using System.Collections;

public class Descartes : MonoBehaviour
{
		Vector2 vec;

		void Start ()
		{
				float x = 25 * Mathf.Cos (Mathf.Deg2Rad * 30);
				float y = 25 * Mathf.Sin (Mathf.Deg2Rad * 30);
				vec = new Vector2 (x, y);
				print (vec);
		}
}
