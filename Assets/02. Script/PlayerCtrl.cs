using UnityEngine;
using System.Collections;
using Name_Maze;
public class PlayerCtrl : MonoBehaviour {
	public CharacterState CS;
	private float v;
	private float h;
	public Transform tr;
	public float moveSpeed=5.0f;
	public float rotateSpeed=100.0f;
	private Animation ani;
	private GameObject Character1;

	public JoyStick MyStick;
	public bool SlerpMode = false;
	public GameButton Bbutton;
	private bool BbuttonIsClick = false;


	private float JumpTimer =2.5f;
	public float CheckTimer=2f;

	public Transform MinTr;//플레이어와 가장 가까이에있는 오브젝트
	public bool Auto=false;//오토타겟 키고끄는 변수
	// Use this for initialization
	void Awake(){
		CS = CharacterState.Idle;
		tr = GetComponent<Transform> ();
		ani = GameObject.Find ("Character1").GetComponent<Animation> ();
		GetComponent<Rigidbody> ().WakeUp ();
		 
	}
	void Start () {
		StartCoroutine (CheckCharacterState ());

	}
	void AutoTarget(){
		Collider[] colls = Physics.OverlapSphere (tr.position, 10.0f);
	
		float Min = 10.0f;
		foreach (Collider coll in colls) {
			Debug.Log(coll);

			if(coll.gameObject.tag=="Monster"){
				if(Min>Distance(coll.transform,tr)){
					Auto = true;
					Min=Distance(coll.transform,tr);
					MinTr = coll.transform;
//					Debug.Log(MinTr);
				}
			}
		}




	}
	float Distance(Transform a,Transform b){
		float x = a.position.x - b.position.x;
		float y = a.position.z - b.position.z;
		float distance = Mathf.Sqrt ((x * x) + (y * y));
		return distance;
	}
	// Update is called once per frame
	void Update () {
		if (CS == CharacterState.Idle && !GameObject.Find("Main Camera").GetComponent<RaycastTest>().isTarget) {
			AutoTarget ();
		}

//		Debug.Log (CS);
//		Debug.Log ("플레이어위치 : " + tr.position.ToString ());
		CheckTimer += Time.deltaTime;
		v = Input.GetAxis ("Vertical");
		h = Input.GetAxis ("Horizontal");
		if (Input.GetKey (KeyCode.W)) {

		} else if (Input.GetKey (KeyCode.S)) {

		} else if (Input.GetKey (KeyCode.Space)) {
//			ani.Play("Attack");
		} else {
//			ani.Play("idle");
		}
		Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);

		//tr.Translate (moveDir * moveSpeed * Time.deltaTime, Space.Self);

		//tr.Rotate(Vector3.up*Time.deltaTime*rotateSpeed*Input.GetAxis("Mouse X"));

		if (MyStick.isClick && CS!=CharacterState.Disabled) {
			//Debug.Log("Stick");
			CS = CharacterState.Walk;
			transform.Translate (Vector3.forward * 4.0f * Time.deltaTime);
			

				//transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.AngleAxis (MyStick.Degree, Vector3.up), Time.deltaTime * 2.0f); // 스틱 방향으로 서서히 회전
			
				transform.rotation = Quaternion.AngleAxis (MyStick.Degree, Vector3.up); // 스틱 방향으로 바로 회전
			
		} 
		if (!MyStick.isClick && !Bbutton.isClick) {
			CS=CharacterState.Idle;
		}
		if (Bbutton.isClick) {

			//Debug.Log("Bbutton is clicked");

			if((CS==CharacterState.Walk || CS==CharacterState.Idle) && CheckTimer > JumpTimer){
				CS=CharacterState.Jump;
				Jump ();
				CheckTimer=0f;
			}

		} else {
			//CS = CharacterState.Idle;
		}


	}
	void OnColliderEnter(Collision coll){
		if (coll.gameObject.name == "AutoTargetImage") {
			//Debug.Log(coll);
			//CS=CharacterState.Idle;
		}
	}
	void Jump()
	{
		StartCoroutine (StartJump ());
		GetComponentInChildren<Rigidbody> ().AddForce (Vector3.up * 400f);
		
	}
	IEnumerator StartJump(){
		CS=CharacterState.Jump;
		yield return new WaitForSeconds (2.0f);
		CS=CharacterState.Idle;
	}
	IEnumerator CheckCharacterState(){
		while (CS!=CharacterState.Dead) {
			switch(CS){
			case CharacterState.Attack:
				//Debug.Log("Attack");
				ani.Play("Attack");
				break;
			case CharacterState.Dead:
				Debug.Log("Dead");
				break;
			case CharacterState.Idle:
				//Debug.Log("Idle");
				ani.Play("idle");
				break;
			case CharacterState.Jump:
				//Debug.Log("Jump");
				ani.Play("Jump");
				break;
			case CharacterState.Attacked:
				//Debug.Log("Attacked");
				break;
			case CharacterState.Disabled:
				//Debug.Log("Disabled");
				break;
			case CharacterState.Walk:
				//Debug.Log("Walk");
				ani.Play("Walk");
				break;
			case CharacterState.Win:
				//Debug.Log("Win");
				break;
				
			}
			yield return null;
		}
		
	}

}
