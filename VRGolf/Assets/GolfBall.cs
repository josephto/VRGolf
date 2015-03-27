using UnityEngine;
using System.Collections;

public class GolfBall : MonoBehaviour {

	public bool cameraFollow = false;
	private float distanceFromBall = 50f;
	public Transform flagPos;
	private Camera mainCamera;
	private SphereCollider golfBallCollider;

	// Use this for initialization
	void Start () {
		mainCamera = Camera.main;
		golfBallCollider = this.gameObject.GetComponent<SphereCollider>();
	}
	
	// Update is called once per frame
	void Update () {
		if (cameraFollow) {

			//make collider size of ball
			golfBallCollider.radius = transform.localScale.x/2.0f;
			golfBallCollider.center = new Vector3(0,0,0);

			Vector3 dir = (this.gameObject.transform.position+new Vector3(0,2,0) - flagPos.position).normalized;
			mainCamera.transform.position = this.gameObject.transform.position +new Vector3(0,02) + dir*distanceFromBall;

			//toa
			float angle = Mathf.Atan(2/(this.gameObject.transform.position - flagPos.position).magnitude);

			mainCamera.transform.LookAt (flagPos);
		}else{

			//make collider larger
			golfBallCollider.radius = transform.localScale.x;
			golfBallCollider.center = new Vector3(0,transform.localScale.x/2.0f,0);
		}
		Debug.LogError ("golfball velocity: "+this.gameObject.rigidbody.velocity);
	}
}
