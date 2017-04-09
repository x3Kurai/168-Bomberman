using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door2 : MonoBehaviour {

	public GameObject enemy;
	public GameObject enemy2;

	// Update is called once per frame
	void Update () {
		if (!enemy && !enemy2)
			Destroy (gameObject);
	}
}
