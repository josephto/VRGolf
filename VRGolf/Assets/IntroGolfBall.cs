using UnityEngine;
using System.Collections;

public class IntroGolfBall : MonoBehaviour {

	private Vector3 startPosition;
	private GolfManager golfManager;

	// Use this for initialization
	void Start () {
		startPosition = transform.position;
		golfManager = GameObject.Find ("GolfManager").GetComponent<GolfManager>();
	}

	void Update(){
		if (transform.position.x != startPosition.x ||
		    transform.position.y != startPosition.y ||
		    transform.position.z != startPosition.z){
			Debug.LogError(transform.position);
			Debug.LogError(startPosition);
			golfManager.intro = false;
			Application.LoadLevel("VRGolf");

		}
	}

}
