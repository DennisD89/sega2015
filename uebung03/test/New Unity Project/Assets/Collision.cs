using UnityEngine;
using System.Collections;

public class Collision : MonoBehaviour {
	Renderer renderer;
	public Material intactMaterial;
	public Material hitMaterial;
	
	// Use this for initialization
	void Start () {
		renderer = GetComponent<Renderer>();
		renderer.material = intactMaterial;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			renderer.material = hitMaterial;
		}		
	}
}
