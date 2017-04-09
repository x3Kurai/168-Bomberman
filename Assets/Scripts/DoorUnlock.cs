using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorUnlock : MonoBehaviour {

	public GameObject enemy;

	// Update is called once per frame
	void Update () {
		if (!enemy)
			Destroy (gameObject);
	}
}
