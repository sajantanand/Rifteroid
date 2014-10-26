using UnityEngine;
using System.Collections;

using Pose = Thalmic.Myo.Pose;
using VibrationType = Thalmic.Myo.VibrationType;

public class GameController : MonoBehaviour
{
	public GameObject hazard;
	public Vector3 spawnValues;
	public Vector3 spawnValues2;
	public int hazardCount;
	public int hazardCount2;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	private bool gameOver;
	private bool restart;

	public GameObject myo = null;
	
	void Start ()
	{
		gameOver = false;
		restart = false;
		StartCoroutine (SpawnWaves ());
	}

	void Update ()
	{
		if (restart)
		{
			ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo> ();

			if (thalmicMyo.pose == Pose.ThumbToPinky)
			{
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}
	
	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
				Vector3 spawnPosition = new Vector3 (Random.Range (-100, spawnValues.x), Random.Range (-100, spawnValues.y), spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);



				yield return new WaitForSeconds (spawnWait);
			}

			for (int i = 0; i < hazardCount2; i++)
			{
			Vector3 spawnPosition2 = new Vector3 (Random.Range (-5, spawnValues2.x), Random.Range (-5, spawnValues2.y), spawnValues2.z);
			Quaternion spawnRotation2 = Quaternion.identity;
			Instantiate (hazard, spawnPosition2, spawnRotation2);
			yield return new WaitForSeconds (waveWait);
			}

			if (gameOver)
			{
			
				restart = true;
				break;
			}
		}
	}
	public void GameOver ()
	{

		gameOver = true;
	}
}