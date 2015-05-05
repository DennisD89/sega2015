using UnityEngine;
using System.Collections;

public class Lerp : MonoBehaviour {
	Renderer renderer;
	// Is the unpowered material (before the user drags to shoot)
	public Material unpoweredMaterial;
	// Is the maximum powered material
	public Material poweredMaterial;

	float speedFactor;

	// Use this for initialization
	void Start () {
		renderer = GetComponent<Renderer>();
		renderer.material = unpoweredMaterial;

		speedFactor = 0;
	}
	
	// Update is called once per frame
	void Update () {
		renderer.material.Lerp(unpoweredMaterial, poweredMaterial, speedFactor);
	}

	public void SetSpeedFactor(float speedFactor) {
		this.speedFactor = speedFactor;
	}
}