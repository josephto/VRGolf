using UnityEngine;
using System.Collections;

public class GolfClub : MonoBehaviour {

	private Vector3 oldPosition;
	private Vector3 velocity;
	public bool contact = false;
	public AudioClip golfSwingSound;
	public AudioClip golfHitSound;
	public Transform flagPos;
	public bool putter;
	private GolfManager golfManager;

	private float nextSoundTime = 0f;

	// Use this for initialization
	void Start () {
		oldPosition = transform.position;
		golfManager = GameObject.Find ("GolfManager").GetComponent<GolfManager>();
	}

	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate(){
		Vector3 newPosition = transform.position;
		velocity = (newPosition - oldPosition) / Time.deltaTime;
		if (!contact){
			Vector3 origin = oldPosition;
			Vector3 direction = (newPosition-origin).normalized;
			RaycastHit hit = new RaycastHit();

			//sttill need to fix back swing

			if(Physics.Raycast(origin, direction, out hit) && 
			   velocity.magnitude > (flagPos.position - transform.position).magnitude /4f && //minimum velocity
			   velocity.magnitude < 10000 && //max velocity
			   Vector3.Dot (velocity.normalized, (flagPos.position - newPosition).normalized) > 0){ //fix back swing

				if (hit.collider.name == "GolfBall"){
					if (putter){
						hit.collider.gameObject.rigidbody.velocity = new Vector3(velocity.x/15f,velocity.y/30f, velocity.z/15f);
					}else{
						hit.collider.gameObject.rigidbody.velocity = velocity/13f;
					}
					contact = true;
					GolfBall golfBall = hit.collider.gameObject.GetComponent<GolfBall>();
					if (golfBall != null){
						golfBall.cameraFollow = true;
						golfBall.gameObject.rigidbody.constraints = RigidbodyConstraints.None;
					}
					golfManager.IncrementStrokes();
					audio.PlayOneShot (golfHitSound);
				}
			}
		}
		oldPosition = newPosition;
	}
}
