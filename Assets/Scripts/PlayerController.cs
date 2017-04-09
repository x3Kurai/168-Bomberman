﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public Text noOfBombs;
	public float moveSpeed = 5f;
	public bool canDropBombs = true; //Can the player drop bombs?
	public bool canMove = true; //Can the player move?
	public bool dead = false;
	private bool bombExisted = false;
	public int bombs = 1; //Amount of bombs the player has left to drop, gets decreased as the player drops a bomb, increases as an owned bomb explodes
	public int range = 2;

	public GameObject bombPrefab;

	private Rigidbody rigidBody;
	private Transform myTransform;

	// Use this for initialization
	void Start() {
		rigidBody = GetComponent<Rigidbody>();
		myTransform = transform;
		SetBombText ();

	}
		
	void Update() {
		if (!canMove) { 
			return;
		}

		UpdatePlayer1Movement ();
	}


	private void UpdatePlayer1Movement() {
		if (Input.GetKey(KeyCode.UpArrow)) { //Up movement
			rigidBody.velocity = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y, moveSpeed);
			myTransform.rotation = Quaternion.Euler(0, 0, 0);
		}

		if (Input.GetKey(KeyCode.LeftArrow)) { //Left movement
			rigidBody.velocity = new Vector3(-moveSpeed, rigidBody.velocity.y, rigidBody.velocity.z);
			myTransform.rotation = Quaternion.Euler(0, 270, 0);
		}

		if (Input.GetKey(KeyCode.DownArrow)) { //Down movement
			rigidBody.velocity = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y, -moveSpeed);
			myTransform.rotation = Quaternion.Euler(0, 180, 0);
		}

		if (Input.GetKey(KeyCode.RightArrow)) { //Right movement
			rigidBody.velocity = new Vector3(moveSpeed, rigidBody.velocity.y, rigidBody.velocity.z);
			myTransform.rotation = Quaternion.Euler(0, 90, 0);
		}

		if (canDropBombs && Input.GetKeyDown(KeyCode.Space)) {
			DropBomb();
		}
	}


	private void DropBomb() {
		if (bombPrefab && !bombExisted && bombs > 0) {
			Instantiate (bombPrefab, new Vector3(Mathf.RoundToInt(myTransform.position.x), myTransform.position.y, Mathf.RoundToInt(myTransform.position.z)), bombPrefab.transform.rotation);
			bombExisted = true;
			bombs--;
			SetBombText ();
		}
	}

	public void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("Explosion")) {
			dead = true;
			gameObject.SetActive (false);
		} else if (other.CompareTag ("BombUpgrade")) {
			bombs += 2;
			SetBombText ();
		} else if (other.CompareTag ("RangeUpgrade")) {
			range++;
		}
	}

	public void OnCollisionEnter(Collision other) {
		if (other.gameObject.CompareTag ("Enemy")) {
			dead = true;
			gameObject.SetActive(false);
		}
	}

	public void OnTriggerExit(Collider other) {
		if (other.gameObject.CompareTag("Bomb")) { // When the player exits the bomb
			bombExisted = false;
		}
	}

	public void SetBombText(){
		noOfBombs.text = "Bombs Available: " + bombs.ToString () + "\n\r" + "Press Escape to pause" + "\n\r" + "Press Q to restart level" ;
	}

}