using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

	public float rotateX;
	public float rotateY;
	public float rotateZ;

	// Before rendering each frame..
	void Update () 
	{
		// Rotate the game object that this script is attached to
		transform.Rotate (new Vector3 (rotateX, rotateY, rotateZ) * Time.deltaTime);
	}
}	
