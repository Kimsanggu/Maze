using UnityEngine;
using System.Collections;

public class aaa : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	IEnumerator Delay(float time){
		yield return new WaitForSeconds (time);
		Debug.Log ("Time");

	}
	// Update is called once per frame
	void Update () {

	}
}
