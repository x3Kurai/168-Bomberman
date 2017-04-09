using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating : MonoBehaviour {
	
	private bool goingDown;
	public GameObject manager;

	void Start () {
		goingDown = true;
	}

	void Update() {
		if (goingDown) {
			transform.Translate (Vector3.down * Time.deltaTime, Space.World);
			if (transform.position.y <= 0.9f)
				goingDown = false;
		}
		else {
		transform.Translate (Vector3.up * Time.deltaTime, Space.World);
			if (transform.position.y >= 1.278f)
				goingDown = true;
		}
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.CompareTag ("Player")) {
			manager.GetComponent<AudioSource>().Play ();
			gameObject.SetActive (false);
		}
	}


}
