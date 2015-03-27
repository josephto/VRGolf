using UnityEngine;
using System.Collections;

public class GolfClub : MonoBehaviour {

	private Vector3 oldPosition;
	private Vector3 velocity;
	private bool contact = false;

	// Use this for initialization
	void Start () {
		oldPosition = transform.position;
	}

//	void OnTriggerEnter(Collider other){
//		if(other.gameObject.name == "Sphere"){
//			Debug.LogError ("Enter "+velocity);
//			other.gameObject.rigidbody.velocity = velocity;
//		}
//	}

//	void OnTriggerStay(Collider other){
//		if(other.gameObject.name == "Sphere"){
//			Debug.LogError ("Stay "+velocity);
//			other.gameObject.rigidbody.velocity = velocity*2f;
//		}
//	}
//
//	void OnTriggerExit(Collider other){
//		if(other.gameObject.name == "Sphere"){
//			Debug.LogError ("Exit "+velocity);
//			other.gameObject.rigidbody.velocity = velocity*2f;
//		}
//	}

	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate(){
		Vector3 newPosition = transform.position;
		velocity = (newPosition - oldPosition) / Time.deltaTime;
		if (!contact){
			Vector3 origin = newPosition;
			Vector3 direction = (oldPosition-origin).normalized;
			RaycastHit hit = new RaycastHit();
			if(Physics.Raycast(origin, direction, out hit) && velocity.magnitude > 1000f ){ //threshold for swing arbitrary
				if (hit.collider.name == "GolfBall"){
					Debug.LogError ("velocity in FixedUpdate: "+velocity/15f);
					hit.collider.gameObject.rigidbody.velocity = velocity/15f;
					contact = true;
					GolfBall golfBall = hit.collider.gameObject.GetComponent<GolfBall>();
					if (golfBall != null){
						golfBall.cameraFollow = true;
					}
				}
			}
		}
		oldPosition = newPosition;
	}
}
