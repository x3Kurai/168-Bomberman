using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WanderingAI : MonoBehaviour {


	public float wanderRadius;
	public float wanderTimer;

	private Transform target;
	private NavMeshAgent agent;
	private float timer;
	private float invulnerableTimer;
	private bool canBeKilled;

	void OnEnable() {
		agent = GetComponent<NavMeshAgent> ();
		timer = wanderTimer;
		invulnerableTimer = 2;
		canBeKilled = false;
	}

	void Update() {
		timer += Time.deltaTime;
		invulnerableTimer -= Time.deltaTime;
		if (invulnerableTimer <= 0)
			canBeKilled = true;
		else
			canBeKilled = false;

		if (timer >= wanderTimer) {
			Vector3 newPos = RandomNavSphere (transform.position, wanderRadius, -1);
			agent.SetDestination (newPos);
			timer = 0;
		}

	}

	public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask) {
		Vector3 randDirection = Random.insideUnitSphere * dist;

		randDirection += origin;

		NavMeshHit navHit;

		NavMesh.SamplePosition (randDirection, out navHit, dist, layermask);

		return navHit.position;
	}

	public void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("Explosion") && canBeKilled) {
			canBeKilled = false;
			Invoke("destroyGameObject", 0.3f);
		}
	}

	void destroyGameObject() {
		Destroy (gameObject);
	}
}
