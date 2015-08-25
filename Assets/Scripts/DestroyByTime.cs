using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour {

	public int SecondsToDestroy;

	private System.DateTime startTime;

	void Start () {
		startTime = System.DateTime.Now;
	}

	void Update()
	{
		if((System.DateTime.Now - startTime).TotalSeconds < SecondsToDestroy) return;
		Destroy (gameObject);
	}
}
