using UnityEngine;
using System.Collections;

public class WeaponDestroyByContact : MonoBehaviour {

	public GameObject Blast;

	public int ScoreValue;
	private GameController gameController;

	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag("GameController");
		if (gameControllerObject != null) 
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if(gameController == null)
		{
			Debug.Log ("Cannot find game controller");
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			gameController.AddScore(ScoreValue);
			Destroy (gameObject);
			Instantiate (Blast, transform.position, transform.rotation);
		}
	}
}
