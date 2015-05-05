using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {
	// The class to control the graphics
	Lerp lerp;
	bool released;
	// When was the left mouse button hit?
	float timeMouseButtonDown;
	// The speed of this object
	float speed;
	float speedFactor;
	// Defines the distance between the ball and the camera
	float startDistance = 5.0f;

	// Use this for initialization
	void Start () {
		lerp = GetComponent<Lerp>();

		released = false;
		speed = -5;
	}
	
	// Update is called once per frame
	void Update () {
		handleMouseInputs();

		// If left mouse button is released
		if (released) {
			moveBall();
		// Player is able to control the ball
		} else {
			changeBallPosition();
		}
	}

	private void handleMouseInputs() {
		// Save the time when the left mousbutton has been clicked
		if (Input.GetMouseButtonDown (0)) {
			timeMouseButtonDown = Time.time;
		}

		// Check if left mouse button is held down
		if (Input.GetMouseButton (0)) {
			calculateCurrentSpeedFactor(timeMouseButtonDown, Time.time);
			lerp.SetSpeedFactor(speedFactor);
		}
		
		// Check if left MouseButton has been released
		if (Input.GetMouseButtonUp(0) && !released) {
			released = true;
			calculateSpeed();
		}
	}

	/**
	 * 
	 */
	private void calculateCurrentSpeedFactor(float start, float end) {
		float maxTime = 3.0f;

		float difference = end - start;
		
		if (difference > maxTime) {
			difference = maxTime;
		}
		
		speedFactor = (difference / maxTime);
	}

	/**
	 * Calculates the speed for the ball,
	 * where the speedFactor determines the range of the speed.
	 * But the ball has a minimum speed.
	 */
	private void calculateSpeed() {
		float minSpeed = 5.0f;
		float maxAdditionalSpeed = 40.0f;

		speed = speedFactor * maxAdditionalSpeed + minSpeed;
	}

	/**
	 * Accelerates the ball with the speed.
	 */
	private void moveBall() {
		transform.Translate (0, 0, speed * Time.deltaTime);
	}

	/**
	 * Will position the ball underneath the mouse pointer.
	 */
	private void changeBallPosition() {
		Vector3 newPosition = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, startDistance);
		
		transform.position = Camera.main.ScreenToWorldPoint (newPosition);
	}
}
