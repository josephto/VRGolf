using UnityEngine;
using System.Collections;

public class GolfManager : MonoBehaviour {

	private int numStrokes = 0;
	private int distance;
	public Texture strokes;
	public Texture flag;
	public Texture gradient;
	public Font f;
	public Font m;
	public bool intro;
	private bool victory;
	private GameObject carl;

	// Use this for initialization
	void Start() {
		intro = true;
		victory = false;
		carl = GameObject.Find ("Carl");
	}

	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}

	// Update is called once per frame
	void Update () {
		if (victory){
			Camera.main.transform.LookAt(carl.transform);
			Camera.main.transform.RotateAround(carl.transform.position, Vector3.up, 10f * Time.deltaTime);
			//Debug.LogError ("WHATT");
		}
	}

	public void setVictory(bool v){
		victory = v;
		if (victory){
			carl.transform.position = new Vector3(carl.transform.position.x, 12f, carl.transform.position.z);
			Camera.main.transform.position = carl.transform.position + carl.transform.forward.normalized*70f + new Vector3(0f,15f,0f);
		}
	}

	public void IncrementStrokes(){
		numStrokes++;
	}

	public int getNumStrokes(){
		return numStrokes;
	}

	public void setDistance(int d){
		distance = d;
	}

	void OnGUI(){

		if(!intro){

			//gradient
			GUI.DrawTexture(new Rect(0, 0, 250, 70), gradient, ScaleMode.StretchToFill, true, 0.0F);
			GUI.DrawTexture(new Rect(0, 80, 250, 70), gradient, ScaleMode.StretchToFill, true, 0.0F);

			//strokes
			GUI.DrawTexture(new Rect(15, 10, 50, 50), strokes, ScaleMode.ScaleToFit, true, 0.0F);
			GUI.skin.font = m;
			GUI.skin.label.fontSize = 30;
			GUI.TextArea(new Rect(90,20,160,80), numStrokes.ToString(), "Label");

			//distance
			GUI.DrawTexture(new Rect(5, 85, 60, 60), flag, ScaleMode.ScaleToFit, true, 0.0F);
			GUI.skin.font = m;
			GUI.skin.label.fontSize = 30;
			GUI.TextArea(new Rect(90,95,160,80), (distance).ToString()+" ft", "Label");
		}

		if(victory){
			//victory
			GUI.DrawTexture(new Rect(0, 510, 450, 80), gradient, ScaleMode.StretchToFill, true, 0.0F);
			GUI.skin.font = f;
			GUI.skin.label.fontSize = 60;
			GUI.TextArea(new Rect(20,520,1000,100), "You Won!", "Label");

			//num strokes
			GUI.DrawTexture(new Rect(0, 600, 450, 60), gradient, ScaleMode.StretchToFill, true, 0.0F);
			GUI.skin.font = m;
			GUI.skin.label.fontSize = 40;
			GUI.TextArea(new Rect(20,600,1000,100), "It took "+numStrokes.ToString()+ " strokes!", "Label");
		}
	}
}


