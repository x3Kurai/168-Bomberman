using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door3 : MonoBehaviour {

	public GameObject enemy;
	public GameObject enemy2;
	public GameObject enemy3;
	public GameObject enemy4;
	public GameObject enemy5;
	public GameObject enemy6;

	// Update is called once per frame
	void Update () {
		if (!enemy && !enemy2 && !enemy3 && !enemy4 && !enemy5 && !enemy6)
			Destroy (gameObject);
	}
}
