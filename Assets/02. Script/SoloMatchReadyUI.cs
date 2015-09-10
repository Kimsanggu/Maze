using UnityEngine;
using System.Collections;

public class SoloMatchReadyUI : MonoBehaviour {
	public UserAccount UA;
	private string name;
	private GameObject a;

	// Use this for initialization
	void Start () {
		UA.SetPlayerID ("sanggu");

		Debug.Log (UA.GetPlayerID());

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void GoStart(){
		Application.LoadLevel ("Test");
	}
	void GoQuit(){
		Application.LoadLevel ("Main");
	}
	void OnGUI(){
		GUIStyle LabelStyle = new GUIStyle ();
		LabelStyle.fontSize = 100;
		GUI.Label (new Rect (250, 100, 50, 50),UA.GetPlayerID(),LabelStyle);

	}
}
