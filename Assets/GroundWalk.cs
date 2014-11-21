using UnityEngine;
using System.Collections;

public class GroundWalk : MonoBehaviour
{
		public Transform ground;
		public Transform ball;
		Vector3 q, n, p;
		float y0;
	
		float inputSpeed = 0.1f;
		float mouseSpeed = 1f;
		Transform _ground, _ball;
		float rotx, roty;

		float ballShiftY = 0.5f;

		void Awake ()
		{
				_ground = ground;
				_ball = ball;
		}

		void Update ()
		{
				roty = Input.GetAxis ("Mouse X") * mouseSpeed;
				rotx = Input.GetAxis ("Mouse Y") * mouseSpeed;

				_ground.Rotate (rotx, 0, roty);
				q = ground.position;
				n = ground.up;

				ball.Translate (Input.GetAxis ("Horizontal") * inputSpeed, 0, Input.GetAxis ("Vertical") * inputSpeed);
				p = new Vector3 (Mathf.Clamp (_ball.position.x, -6, 6), _ball.position.y, Mathf.Clamp (_ball.position.z, -6, 6));

				y0 = ((n.x * (q.x - p.x) + n.z * (q.z - p.z)) / n.y) + q.y;	//ここが重要
				_ball.position = new Vector3 (p.x, y0 + ballShiftY, p.z);
		}
}
