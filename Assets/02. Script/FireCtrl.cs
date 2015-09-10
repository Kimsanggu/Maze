using UnityEngine;
using System.Collections;
using Name_Maze;
[RequireComponent(typeof(AudioSource))]
public class FireCtrl : MonoBehaviour {
	public GameObject bullet;
	public Transform firePos;
	public AudioClip fireSfx;
	public GameButton AButton;
	public bool isfire=true;
	public bool isTarget=false;
	private Transform TargetTr;
	public RaycastTest RT;
	public float degree;
	public Transform PlayerTr;
	// Use this for initialization
	void Awake () {
		//RT=GameObject.Find("Main camera"
	}
	
	// Update is called once per frame
	void Update () {
		SetisTarget ();
		SetTarget ();
		if(AButton.isClick && isfire){
			Fire();
		}
		SetRotation ();
	}
	void Fire(){
		StartCoroutine (this.CreateBullet (1.0f));
		StartCoroutine (this.PlaySfx (fireSfx));
	}
	IEnumerator CreateBullet(float time){
		//PlayerTr.LookAt (TargetTr);
		transform.rotation = Quaternion.AngleAxis(degree,Vector3.up);
		Instantiate (bullet, TargetTr.position, TargetTr.rotation);
		isfire = false;
		yield return new WaitForSeconds (time);
		isfire = true;
	}
	IEnumerator PlaySfx(AudioClip _clip){//총알이 벽에 부딪혀서 바로사라질경우 사운드가 재생이 안될때 추가하는 함수
		GetComponent<AudioSource>().PlayOneShot (_clip, 0.9f);
		yield return null;
	}
	void SetRotation(){
//		Rtransform.position = eventData.position - buttonDis;
		
		Vector3 dir = TargetTr.position-PlayerTr.position;
		dir.y = 0;
		degree = (Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg + 360f) % 360f;
		//Debug.Log ("Target : "+TargetTr.position+"Player : "+PlayerTr.position+"Degree :"+degree);
	}
	void SetTarget(){
		if (isTarget) {
			TargetTr = GameObject.Find ("Main Camera").GetComponent<RaycastTest> ().target.transform;

		} else {
			TargetTr=firePos;
		}
	}
	void SetisTarget(){
		isTarget = GameObject.Find ("Main Camera").GetComponent<RaycastTest> ().isTarget;
	}


}
