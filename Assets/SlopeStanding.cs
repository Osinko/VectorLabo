using UnityEngine;
using System.Collections;

public class SlopeStanding : MonoBehaviour
{
		public GameObject planeObj;
		public GameObject playerObj;
		public Transform  pointer;

		Vector3 p0, v, c;
		Transform _player, _pointer;

		void Awake ()
		{
				_player = playerObj.transform;
				_pointer = pointer;
				pointer.position = p0;
		}
		float cy;
		void Update ()
		{
				p0 = planeObj.transform.position;
				v = planeObj.transform.FindChild ("norm").position - p0;
				c = _player.transform.position;
				cy = ((v.x * (p0.x - c.x) + v.z * (p0.z - c.z)) / v.y) + p0.y;	//ここが重要
				_pointer.position = new Vector3 (c.x, cy, c.z);
		}

}
