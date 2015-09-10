using UnityEngine;
using System.Collections;

public class MyGizmo : MonoBehaviour {
	public Color color = Color.yellow;
	public float radius = 0.1f;
	// Use this for initializat
	void OnDrawGizmos(){
		Gizmos.color = color;
		Gizmos.DrawSphere (transform.position, radius);
	}
}
