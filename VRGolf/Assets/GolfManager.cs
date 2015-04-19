using UnityEngine;
using System.Collections;

public class GolfManager : MonoBehaviour {

	private int numStrokes = 0;

	// Use this for initialization
	void Start() {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void IncrementStrokes(){
		numStrokes++;
	}

	public int getNumStrokes(){
		return numStrokes;
	}
}
