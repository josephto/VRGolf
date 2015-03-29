using UnityEngine;
using System.Collections;

public class PuttingGreen : MonoBehaviour {

	public float angularDrag;
	private float originalDrag;

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.name == "GolfBall") {
			originalDrag = other.gameObject.rigidbody.angularDrag;
			other.gameObject.rigidbody.angularDrag = angularDrag;
		}
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject.name == "GolfBall") {
			other.gameObject.rigidbody.angularDrag = originalDrag;
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
