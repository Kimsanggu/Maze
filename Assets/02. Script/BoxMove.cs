using UnityEngine;
using System.Collections;

public class BoxMove : MonoBehaviour {
	private Transform BoxTr;
	private float i = 30.0f;

	// Use this for initialization
	void Start () {
		BoxTr = GetComponent<Transform> ();

	}
	
	// Update is called once per frame
	void Update () {
		BoxTr.position -= new Vector3 (0, 0.1f*i*Time.deltaTime, 0);

		if (BoxTr.position.y <= -1.0f) {
			BoxTr.position=new Vector3 (BoxTr.position.x,1.0f,BoxTr.position.z);
		}
		if (BoxTr.position.y >= 1.1f) {
			i*=-1.0f;
		}
	}
}
