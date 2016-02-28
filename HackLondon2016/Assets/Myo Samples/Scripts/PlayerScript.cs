using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public GameObject playerModel;
	public GameObject boxtip;
	public int wingPower;
	public float outputForce, playerSpeed, maxSpeed;
	public Text currentScore;

	private Vector3 playerPosition;
	private float lastPoint, currentPoint;
	private Rigidbody rb;

	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody>();

		playerPosition = playerModel.transform.position;
		// wingSpan = (playerPosition - boxtip.transform.position).magnitude;
		lastPoint = boxtip.transform.position.y - playerPosition.y;
		currentPoint = boxtip.transform.position.y - playerPosition.y ;

		outputForce = 0;

		SetCountText ();
	
	}
	
	// Update is called once per frame
	void Update () {

		// Get the current position of the box on the tip of the wing
		currentPoint = boxtip.transform.position.y - playerPosition.y;

		// Calculate the change in the wingtip Z positions
		float deltaPoint = currentPoint - lastPoint;

		// If the change in Z position is negative (downwards) then increase player height
		if (deltaPoint < 0) {
			outputForce = -deltaPoint * wingPower;
			rb.AddForce (0.0f, outputForce, 0.0f);
		}

		// Set the last point to the current measured point
		lastPoint = currentPoint;

		// Move the player to the right by the speed factor
		if (rb.velocity.magnitude > maxSpeed) {
			rb.velocity = rb.velocity.normalized * maxSpeed;
		} else {
			rb.AddForce (Vector3.right * playerSpeed);
		}

		SetCountText ();

		maxSpeed += playerPosition.x / 10;
	
	}

	void SetCountText () {
		float playerX = playerModel.transform.position.x;
		currentScore.text = ((int)(100 * playerX)).ToString ();
	}
}
