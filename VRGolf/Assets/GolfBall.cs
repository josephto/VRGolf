using UnityEngine;
using System.Collections;

public class GolfBall : MonoBehaviour {

	public bool cameraFollow = false;
	private float distanceFromBall = 50f;
	public Transform flagPos;
	private Camera mainCamera;
	private SphereCollider golfBallCollider;
	public GameObject golfer; 
	public bool inGreen;

	// Use this for initialization
	void Start () {
		mainCamera = Camera.main; 
		golfBallCollider = this.gameObject.GetComponent<SphereCollider>();
		inGreen = false;
	}

	void LateUpdate(){
		if (cameraFollow && gameObject.rigidbody.velocity.magnitude < 0.5f){
			cameraFollow = false;

			//set ball
			gameObject.rigidbody.useGravity = false;
			gameObject.rigidbody.constraints = RigidbodyConstraints.FreezeAll;
			transform.rotation = Quaternion.identity;


			//set up golfer
			Vector3 ballToFlag = (flagPos.position - transform.position).normalized;
			Vector3 upVector = new Vector3(0,1,0);
			Vector3 crossProd = Vector3.Cross(ballToFlag, upVector).normalized;
			if (inGreen){
				golfer.transform.position = transform.position + crossProd*7.7f - ballToFlag*1.4f;
			}else{
				golfer.transform.position = transform.position + crossProd*8.7f - ballToFlag*2.4f;
			}
			//golfer.transform.position = transform.position + crossProd*8.7f - ballToFlag*2.4f;
			golfer.transform.LookAt(this.gameObject.transform);
			GolfClub golfClub = golfer.GetComponentInChildren<GolfClub>();
			golfClub.contact = false;

			//set up camera
			mainCamera.transform.position = mainCamera.transform.position + new Vector3(0,15,0);
		}

	}

	void FixedUpdate(){
//		if(gameObject.rigidbody.velocity.magnitude < 2f){
//			gameObject.rigidbody.angularVelocity = gameObject.rigidbody.angularVelocity*0.8f;
//		}

		if(gameObject.rigidbody.velocity.magnitude < 2f){
			gameObject.rigidbody.angularVelocity = gameObject.rigidbody.angularVelocity*0.75f;
		}
	}

	// Update is called once per frame
	void Update () {
		if (cameraFollow) {

			//reset gravity
			gameObject.rigidbody.useGravity = true; 

			//make collider size of ball
			golfBallCollider.radius = transform.localScale.x/2.0f;
			golfBallCollider.center = new Vector3(0,0,0);

			//set shadow quality to 1000
			QualitySettings.shadowDistance = 1000f;


			Vector3 dir = (this.gameObject.transform.position+new Vector3(0,2,0) - flagPos.position).normalized;
			mainCamera.transform.position = this.gameObject.transform.position +new Vector3(0,02) + dir*distanceFromBall;

			//toa
			float angle = Mathf.Atan(2/(this.gameObject.transform.position - flagPos.position).magnitude);

			mainCamera.transform.LookAt (flagPos);
		}else{

			//make collider larger IF not in green
			if (!inGreen){
				golfBallCollider.radius = transform.localScale.x;
				golfBallCollider.center = new Vector3(0,transform.localScale.x/2.0f,0);
			}

			//make shadow quality back to 400
			QualitySettings.shadowDistance = 400f;

		}
//		Debug.LogError ("golfball velocity magn: "+this.gameObject.rigidbody.velocity.magnitude);
//		Debug.LogError ("distance from Flag: "+(flagPos.transform.position - transform.position).magnitude);
	}
}
