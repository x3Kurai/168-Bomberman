using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour {
	
	public float Delay = 0.3f;

	void Start() {
		Destroy(gameObject, Delay);
	}
}
