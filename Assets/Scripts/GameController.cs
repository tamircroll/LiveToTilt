using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject hazard, weaponA;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait, startWait, waveWait;

	public GUIText scoreText, restartText, gameOverText;

	private int score;
	private bool gameOver , restart;


	void Start()
	{
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		Screen.orientation = ScreenOrientation.LandscapeLeft;
		gameOver = false; 
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		score = 0;
		updateScore ();
		StartCoroutine (SpawnWaves ());
		StartCoroutine (WeaponsCreator ());
	}

	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i ++) {
				Vector3 spawnPosition = new Vector3(
					Random.Range (-spawnValues.x, spawnValues.x),
					0,
					Random.Range (-spawnValues.z, spawnValues.z));
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
				if(gameOver)
				{
					break;
				}
			}

			if(gameOver)
			{
				break;
			}
			yield return new WaitForSeconds (waveWait);
		}
	}

	void Update()
	{
		if (restart) 
		{
			if(Input.GetKeyDown (KeyCode.R) || Input.touchCount > 0)
			{
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}

	IEnumerator WeaponsCreator()
	{
		yield return new WaitForSeconds (startWait);
		float weaponWait;
		while (true) {
			weaponWait = Random.Range (2.0F, 10.0F);
			Vector3 weaponPosition = new Vector3 (
				Random.Range (-spawnValues.x, spawnValues.x),
				0,
				Random.Range (-spawnValues.z, spawnValues.z));
			Quaternion spawnRotation = Quaternion.identity;
			Instantiate (weaponA, weaponPosition, spawnRotation);

			if (gameOver) {
				restartText.text = "Tap the screen to Restart";
				restart = true;
				GameObject[] gameControllerObject = GameObject.FindGameObjectsWithTag("Enemy");
				destroyAll(gameControllerObject);
				gameControllerObject = GameObject.FindGameObjectsWithTag("Weapon");
				destroyAll(gameControllerObject);
				break;
			}

			yield return new WaitForSeconds (weaponWait);
		}
	}

	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		updateScore ();
	}

	void updateScore()
	{
		scoreText.text = "Score " + score;
	}

	public void GameOver()
	{
		gameOverText.text = "Game Over";
		gameOver = true;
	}

	void destroyAll(GameObject[] all)
	{
		foreach(GameObject obj in all)
		{
			Destroy (obj);
		}
	}
}





