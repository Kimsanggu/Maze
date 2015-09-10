using UnityEngine;
using System.Collections;

public class SoloMatchManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void GoBack(){
		Application.LoadLevel ("SoloMatchReady");
	}
}
