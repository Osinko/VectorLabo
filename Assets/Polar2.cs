using UnityEngine;
using System.Collections;

public class Polar2 : MonoBehaviour
{
		float hypotenuse, theta;

		void Start ()
		{
				hypotenuse = Mathf.Sqrt (35 * 35 + 82 * 82);
				theta = Mathf.Rad2Deg * Mathf.Atan2 (82, 35);
				print (string.Format ("{0}@{1}°", hypotenuse, theta));
		}
}
