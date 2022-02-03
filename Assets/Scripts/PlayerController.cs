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
			gameObject.transform.position = new Vector3(0, 0, 0);
			rb.velocity = Vector3.zero;
		}

		if (other.gameObject.CompareTag("Fallaway"))
		{
			StartCoroutine(Fallaway(other));
		}
	}

    void OnMove(InputValue value)
    {
        Vector2 v = value.Get<Vector2>();
        movementX = v.x;
        movementY = v.y;
    }

	IEnumerator Fallaway(Collider other)
	{
		yield return new WaitForSeconds(.5f);
		other.gameObject.transform.position = new Vector3(other.gameObject.transform.position.x, -1, other.gameObject.transform.position.z);
		yield return new WaitForSeconds(1f);
		other.gameObject.transform.position = new Vector3(other.gameObject.transform.position.x, -.4f, other.gameObject.transform.position.z);

		StopCoroutine(Fallaway(other));
	}
}