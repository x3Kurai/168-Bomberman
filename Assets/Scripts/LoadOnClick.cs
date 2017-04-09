using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadOnClick : MonoBehaviour {

	public void LoadS() {
		SceneManager.LoadScene ("bomberman");
	}

	public void LoadTut() {
		SceneManager.LoadScene ("Tutorial");
	}
}
