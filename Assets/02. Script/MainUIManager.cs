using UnityEngine;
using System.Collections;

public class MainUIManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void GoMazeMaker(){
		Application.LoadLevel ("MazeMaker");
	}
	void GoSoloMatch(){
		Application.LoadLevel ("SoloMatchReady");
	}
}
