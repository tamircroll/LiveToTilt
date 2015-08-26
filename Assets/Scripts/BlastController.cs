using UnityEngine;
using System.Collections;

public class BlastController : MonoBehaviour
{
	public float growTime;
	public float growSpeed;
	
	private System.DateTime startTime;
	
	void Start () {
		startTime = System.DateTime.Now;
	}
	
	void Update()
	{
		if((System.DateTime.Now - startTime).TotalMilliseconds < growTime){
			Vector3 scale = new Vector3 (growSpeed, growSpeed, growSpeed);
			transform.localScale += scale;
		}
	}
}
