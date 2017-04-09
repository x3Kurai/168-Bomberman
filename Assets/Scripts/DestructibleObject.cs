using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleObject : MonoBehaviour {
	
	public void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("Explosion")) {
			Invoke("destroyGameObject", 0.3f);
		}
	}

	void destroyGameObject() {
		Destroy (gameObject);
	}
}
