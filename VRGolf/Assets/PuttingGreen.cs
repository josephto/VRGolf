using UnityEngine;
using System.Collections;

public class PuttingGreen : MonoBehaviour {

	public float angularDrag;
	private float originalDrag;
	public GameObject golfer;

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.name == "GolfBall") {
			originalDrag = other.gameObject.rigidbody.angularDrag;
			other.gameObject.rigidbody.angularDrag = angularDrag;
			GolfBall golfBall = other.gameObject.GetComponent<GolfBall>();
			if (golfBall != null)
				golfBall.inGreen = true;
			golfer.transform.FindChild ("GolfClub").gameObject.SetActive (false);
			golfer.transform.FindChild ("GolfPutter").gameObject.SetActive (true);
		} 
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject.name == "GolfBall") {
			other.gameObject.rigidbody.angularDrag = originalDrag;
			GolfBall golfBall = other.gameObject.GetComponent<GolfBall>();
			if (golfBall != null)
				golfBall.inGreen = false;
			golfer.transform.FindChild ("GolfClub").gameObject.SetActive (true);
			golfer.transform.FindChild ("GolfPutter").gameObject.SetActive (false);
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
