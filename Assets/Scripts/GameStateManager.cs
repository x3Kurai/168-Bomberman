using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameStateManager : MonoBehaviour {

	public GameObject player;
	public GameObject winningSound;
	public bool win;
	private GameObject temp;
	private bool winOnce;

	void Start() {
		win = false;
		winOnce = true;
		player = GameObject.Find ("BomberMan");
	}
		
	void Update () {
		if (player.GetComponent<PlayerController> ().dead == false) {
			if (Input.GetKeyDown (KeyCode.Escape)) {
				if (Time.timeScale != 0)
					Time.timeScale = 0;
				else
					Time.timeScale = 1;
			}
		} else
			StartCoroutine (waitToRestart());

		if (Input.GetKeyDown (KeyCode.Q))
			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);

		temp = GameObject.FindWithTag ("Enemy");
		if (temp == null)
			win = true;
		
		if (win && winOnce) {
			winningSound.GetComponent<AudioSource> ().Play ();
			winOnce = false;
			SceneManager.LoadScene("win");
		}
	}

	private IEnumerator waitToRestart() {
		yield return new WaitForSeconds (1);
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
}

