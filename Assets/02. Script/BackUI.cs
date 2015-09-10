using UnityEngine;
using System.Collections;

public class BackUI : MonoBehaviour {
	private Transform tr;
	// Use this for initialization
	void Start () {
		tr = GetComponent<Transform> ();
		tr.position = new Vector3 (Screen.width + 100, Screen.height + 100, 0.0f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
