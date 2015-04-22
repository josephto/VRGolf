using UnityEngine;
using System.Collections;

public class IntroUI : MonoBehaviour {

	public Texture gradient;
	public Font f;
	public Font m;
	private GolfManager golfManager;

	// Use this for initialization
	void Start () {
		golfManager = GameObject.Find ("GolfManager").GetComponent<GolfManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		GUI.DrawTexture(new Rect(0, 10, 1200, 100), gradient, ScaleMode.StretchToFill, true, 0.0F);
		GUI.skin.font = f;
		GUI.skin.label.fontSize = 50;
		GUI.TextArea(new Rect(20,30,1000,100), "Virtual Reality Golf Simulator", "Label");
		
		GUI.DrawTexture(new Rect(0, 120, 510, 70), gradient, ScaleMode.StretchToFill, true, 0.0F);
		GUI.skin.font = m;
		GUI.skin.label.fontSize = 30;
		GUI.TextArea(new Rect(20,130,1000,100), "Senior Project by Joseph Tong", "Label");
		
		GUI.DrawTexture(new Rect(0, 580, 410, 70), gradient, ScaleMode.StretchToFill, true, 0.0F);
		GUI.skin.label.fontSize = 30;
		GUI.TextArea(new Rect(20,590,1000,100), "Hit the golfball to play!", "Label");
	}

	void OnTriggerExit(Collider c){
		if (c.gameObject.name == "GolfBallFake"){
			golfManager.intro = false;
			Application.LoadLevel("VRGolf");
		}
	}

}
