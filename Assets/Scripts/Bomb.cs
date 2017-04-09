using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

	public GameObject explosionPrefab;
	public LayerMask levelMask;
	private bool exploded = false;
	public GameObject player;
	private int range;


	// Use this for initialization
	void Start () {
		Invoke ("Explode", 3f);
		player = GameObject.Find ("BomberMan");
		range = player.GetComponent<PlayerController> ().range;
	}

	void Update() {
		range = player.GetComponent<PlayerController> ().range;
	}

	void Explode() {
		Instantiate (explosionPrefab, transform.position, Quaternion.identity);

		StartCoroutine (CreateExplosion(Vector3.forward));
		StartCoroutine (CreateExplosion (Vector3.right));
		StartCoroutine (CreateExplosion (Vector3.back));
		StartCoroutine (CreateExplosion (Vector3.left));

		GetComponent<MeshRenderer> ().enabled = false;
		exploded = true;
		transform.FindChild ("Collider").gameObject.SetActive (false);
		Destroy (gameObject, 0.3f);
		if (player) {
			player.GetComponent<PlayerController> ().bombs++;
			player.GetComponent<PlayerController> ().SetBombText ();
		}
	}

	private IEnumerator CreateExplosion(Vector3 direction) {
		
		for (int i = 1; i < range; i++) {
			RaycastHit hit;
			Physics.Raycast (transform.position + new Vector3 (0, 0.5f, 0), direction, out hit, i, levelMask);

			if (!hit.collider)
				Instantiate (explosionPrefab, transform.position + (i * direction), explosionPrefab.transform.rotation);
			else {
				Instantiate (explosionPrefab, transform.position + (i * direction), explosionPrefab.transform.rotation);
				break;
			}
			yield return new WaitForSeconds (0.05f);
		}
	}

	public void OnTriggerEnter (Collider other) {
		if (!exploded && other.CompareTag ("Explosion")) {
			CancelInvoke ("Explode");
			Explode ();
		}
	}
}
