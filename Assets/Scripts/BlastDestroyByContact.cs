using UnityEngine;
using System.Collections;

public class BlastDestroyByContact : MonoBehaviour {

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
		if (other.tag == "Enemy")
		{
			gameController.AddScore(ScoreValue);
			Destroy(other.gameObject);
		}
	}
}
