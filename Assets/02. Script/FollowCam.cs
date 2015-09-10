using UnityEngine;
using System.Collections;

public class FollowCam : MonoBehaviour {//카메라에 부착
	public Transform target;//타겟변수
	public float dist;//타겟과 카메라의 거리
	public float height;//타겟과 카메라의 높이
	public float dampRotate;//부드러운 회전을위한 변수

	private Transform tr;//카메라 자신의 Transform 변수
	// Use this for initialization
	void Start () {
		tr = GetComponent<Transform> ();
		dist = 5.0f;
		height=8.0f;
		dampRotate = 5.0f;
	}
	
	// Update is called once per frame
	void Update () {

	}
	void LateUpdate(){
		float curryYAngle = Mathf.LerpAngle (tr.eulerAngles.y,
		                                    target.eulerAngles.y,
		                                    dampRotate * Time.deltaTime);
		Quaternion rot = Quaternion.Euler (0, curryYAngle, 0);

		tr.position = target.position - (Vector3.forward * dist) 
			+ (Vector3.up * height);

		tr.LookAt (target);

	}
}
