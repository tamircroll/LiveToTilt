using UnityEngine;
using System.Collections;

public class DestroyPlayer : MonoBehaviour {

	public GameObject playerExplosion;
	
	private System.DateTime startTime;
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
		startTime = System.DateTime.Now;

	}
	
	void OnTriggerEnter(Collider other)
	{
		if ((System.DateTime.Now - startTime).TotalSeconds < 2)
				return;
		if (other.tag == "Player") {
			Destroy (gameObject);
			Destroy (other.gameObject);
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			gameController.GameOver ();
		}
	}
}