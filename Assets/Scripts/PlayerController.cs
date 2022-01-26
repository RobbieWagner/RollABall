using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.IO;
using TMPro;

public class PlayerController : MonoBehaviour {
	
	public float speed;
	public ScoreboardLevel1 scoreboard;
	public GameObject storyDriver;

    private float movementX;
    private float movementY;

	private Rigidbody rb;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		scoreboard = GameObject.Find("ScoreText").GetComponent<ScoreboardLevel1>();
	}

	void FixedUpdate()
	{
		Vector3 movement = new Vector3 (movementX, 0.0f, movementY);
		rb.AddForce(movement * speed);
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag("PickUp"))
		{
			other.gameObject.SetActive (false);
			if(scoreboard != null)
			{
				scoreboard.score += 1;
			}
		}

		if (other.gameObject.CompareTag("FakeCoin"))
		{
			storyDriver.SetActive(true);
		}

		if (other.gameObject.CompareTag("Harmful"))
		{
			gameObject.transform.position = new Vector3(0,0,0);
		}
	}

    void OnMove(InputValue value)
    {
        Vector2 v = value.Get<Vector2>();
        movementX = v.x;
        movementY = v.y;
    }
}