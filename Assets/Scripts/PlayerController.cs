using UnityEngine;
using System.Collections;

using Pose = Thalmic.Myo.Pose;
using VibrationType = Thalmic.Myo.VibrationType;


public class PlayerController : MonoBehaviour 
{

	
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;

	
	private float nextFire;

	public GameObject myo = null;


	
	void Update ()
	{
		ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo> ();

		//Input.GetButton ("Fire1")
		if ((thalmicMyo.pose == Pose.Fist) && Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			//GameObject shot = 
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);// as GameObject;

			audio.Play ();
		}

		transform.position = new Vector3(0, 0, 0);
	}


}
