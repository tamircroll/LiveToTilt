using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundry
{
	public float xMin, xMax,	zMin, zMax;
}

public class PlayerController : MonoBehaviour {
	
	public float speed;
	public float tilt;
	public Boundry boundry;
	public int ScoreValue;

	private GameController gameController;

	void FixedUpdate()
	{
		float moveHorizontal = Input.acceleration.x;
		float moveVertical = Input.acceleration.y;

		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

		if (movement != Vector3.zero) 
		{
			transform.rotation = Quaternion.LookRotation (movement);
		}
		rigidbody.velocity = movement * speed;
		rigidbody.transform.Translate (movement * speed * Time.deltaTime, Space.World);

		//Keep player in board
		rigidbody.position = new Vector3
			(
				Mathf.Clamp (rigidbody.position.x, boundry.xMin, boundry.xMax),
				0.0f,
				Mathf.Clamp (rigidbody.position.z, boundry.zMin, boundry.zMax)
			);
	}
}
