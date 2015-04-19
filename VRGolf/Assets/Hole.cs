using UnityEngine;
using System.Collections;

public class Hole : MonoBehaviour {

	public float minMagnitude;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other) {
		GameObject collided = other.gameObject;
		if (collided.name == "GolfBall") {
			Debug.LogError (collided.rigidbody.velocity.magnitude);
			if (collided.rigidbody.velocity.magnitude < minMagnitude){
				Debug.LogError ("You've won!");
				collided.rigidbody.constraints = RigidbodyConstraints.FreezeAll;
			}
		}
	}
}
