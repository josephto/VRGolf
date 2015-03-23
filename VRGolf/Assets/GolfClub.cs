using UnityEngine;
using System.Collections;

public class GolfClub : MonoBehaviour {

	private Vector3 oldPosition;
	private Vector3 velocity;

	// Use this for initialization
	void Start () {
		oldPosition = transform.position;
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.name == "Sphere"){
			Debug.LogError ("Enter "+velocity);
			other.gameObject.rigidbody.velocity = velocity*2f;
		}
	}

	void OnTriggerStay(Collider other){
		if(other.gameObject.name == "Sphere"){
			Debug.LogError ("Stay "+velocity);
			other.gameObject.rigidbody.velocity = velocity*2f;
		}
	}

	void OnTriggerExit(Collider other){
		if(other.gameObject.name == "Sphere"){
			Debug.LogError ("Exit "+velocity);
			other.gameObject.rigidbody.velocity = velocity*2f;
		}
	}

	// Update is called once per frame
	void Update () {
		Vector3 newPosition = transform.position;
		velocity = (newPosition - oldPosition) / Time.deltaTime;
		oldPosition = newPosition;
	}
}
