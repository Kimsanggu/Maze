using UnityEngine;
using System.Collections;

public class AirBombDestroy : MonoBehaviour {

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.name == "unitychan") {
			Destroy(gameObject);
		}
		if (col.gameObject.name == "Maze") {
			Destroy(gameObject);
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
