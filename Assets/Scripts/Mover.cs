using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
	private Transform target;
	float speed = 10f;
	Rigidbody myRigid;
	System.DateTime startTime;
	
	private Vector3 _dir;
	private float startSpeed = 0.1f;

	void Start() 
	{
		target = GameObject.FindWithTag("Player").transform;
		startTime = System.DateTime.Now;
	}

	void Update() {
		moveTowardsPlayer ();
	}

	private void moveTowardsPlayer(){
		if(transform != null)
		{
			if((System.DateTime.Now - startTime).TotalSeconds < 2) return;
			if(target){
				_dir = target.position - rigidbody.position;
				_dir.Normalize();
			//	transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_dir), turnSpeed * Time.deltaTime);
				float step = speed * Time.deltaTime;
				transform.rotation = Quaternion.RotateTowards(transform.rotation, target.rotation, step);
			}
			startSpeed += 1.001f;
			transform.position = Vector3.MoveTowards(transform.position,target.transform.position, Mathf.Min(startSpeed, 0.2f));
		}
	}
//	void FixedUpdate() {
//		rigidbody.AddForce(_dir * speed);
//	}


	IEnumerator EnableRenderer() //Blink every time.
	{
		this.renderer.enabled = true;
		yield return new WaitForSeconds(0.2F); //Wait after each blink
	}
}
