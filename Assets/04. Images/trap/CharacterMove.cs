using UnityEngine;
using System.Collections;

public class CharacterMove : MonoBehaviour {
	float moveSpeed = 10f;
	float rotateSpeed = 20f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float moveDistance = moveSpeed * Time.deltaTime * Input.GetAxis ("Vertical");
		gameObject.transform.Translate (0, 0, moveDistance);
		float rotateDistance = rotateSpeed * Time.deltaTime * Input.GetAxis ("Horizontal");
		gameObject.transform.Rotate (0, rotateDistance, 0);
	
	}
}
