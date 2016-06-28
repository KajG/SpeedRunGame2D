using UnityEngine;
using System.Collections;

public class PlayerMovementLR : MonoBehaviour
{
	public float speedR = 0f;
	public float speedL = 0f;
	private float maxSpeedR = 10f;
	private float maxSpeedL = -10f;
	private bool speedUpR = false;
	private bool speedUpL = false;


	void Update ()
	{
		transform.position += Vector3.right * speedR * Time.deltaTime;
		transform.position += Vector3.right * speedL * Time.deltaTime;
		if (Input.GetKeyDown("right"))
		{
			speedUpR = true;
			Debug.Log (speedUpR);
		}
		else if (Input.GetKeyUp("right"))
		{
			speedUpR = false;
			Debug.Log (speedUpR);
		}
		if (speedUpR == true && speedR < maxSpeedR) {
			speedR += 0.5f;
		}
		if (speedUpR == false && speedR > 0) {
			speedR -= 0.5f;
		}



		if (Input.GetKeyDown("left"))
		{
			speedUpL = true;
			Debug.Log (speedUpL);
		}
		else if (Input.GetKeyUp("left"))
		{
			speedUpL = false;
			Debug.Log (speedUpL);
		}
		if (speedUpL == true && speedL > maxSpeedL) {
			speedL -= 0.5f;
		}
		if (speedUpL == false && speedL < 0) {
			speedL += 0.5f;
		}

	}
}