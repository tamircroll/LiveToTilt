using UnityEngine;
using System.Collections;

public class BlastController : MonoBehaviour {

	// Update is called once per frame
	void Update () 
	{
		Vector3 scale = new Vector3 (0.035f, 0.035f, 0.035f);
		transform.localScale += scale;
	}
}
