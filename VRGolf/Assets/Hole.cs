using UnityEngine;
using System.Collections;

public class Hole : MonoBehaviour {

	public float minMagnitude;
	private GolfManager golfManager;

	// Use this for initialization
	void Start () {
		golfManager = GameObject.Find ("GolfManager").GetComponent<GolfManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other) {
		GameObject collided = other.gameObject;
		if (collided.name == "GolfBall") {
			if (collided.rigidbody.velocity.magnitude < minMagnitude){
				collided.transform.position = this.gameObject.transform.position;
				collided.rigidbody.constraints = RigidbodyConstraints.FreezeAll;
				golfManager.setDistance(0);
				golfManager.setVictory(true);
				collided.GetComponent<GolfBall>().cameraFollow = false;
				collided.GetComponent<SphereCollider>().enabled = false;
			}
		}
	}
}
