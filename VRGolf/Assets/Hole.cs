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
			Debug.LogError (collided.rigidbody.velocity.magnitude);
			if (collided.rigidbody.velocity.magnitude < minMagnitude){
				Debug.LogError ("You've won!");
				Debug.LogError ("It took you "+golfManager.getNumStrokes());
				collided.transform.position = this.gameObject.transform.position;
				collided.rigidbody.constraints = RigidbodyConstraints.FreezeAll;
				golfManager.setDistance(0);
				golfManager.victory = true;
			}
		}
	}
}
