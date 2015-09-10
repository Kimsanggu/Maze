using UnityEngine;
using System.Collections;
using Name_Maze;
public class Character1 : Character{
	//public CharacterController cc;
	public Transform player;
	private SphereCollider sc;
	public Animation animation;//애니메이션 동작 변수

	public float moveSpeed = 5f;
	public float turnSpeed = 540f;

	public int clickLayer = 0;
	public int blockLayer = 9;

	bool isMoveState = false;

	Vector3 hitPosition;


	void Awake()
	{	
		//cc = GetComponent<CharacterController>();
		//sc=cc.GetComponent<SphereCollider> ();
		Hp = 100.0f;
		animation = this.GetComponent<Animation> ();
		player = this.GetComponent<Transform> ();
	}
	// Use this for initialization
	void Start () {

		//Debug.Log (player.transform.position);

	}
	
	// Update is called once per frame
	void Update () {/*
		if (Input.GetMouseButton (0)) {
			Debug.Log ("Hit");

			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			RaycastHit hitInfo;

			if(Physics.Raycast(ray,out hitInfo,100f))
			{
				Debug.Log("Hit point : "+hitInfo.point);
				int l = hitInfo.transform.gameObject.layer;
				Debug.Log("l:"+l);
				if(l==0)
				{
					Debug.Log ("hit object :"+hitInfo.collider.name);
					hitPosition = hitInfo.point;
					isMoveState=true;
				}
			}
		}
		if (isMoveState) {
			player.transform.position = new Vector3(hitPosition.x,0f,hitPosition.z);
			//Debug.DrawRay(transform.position,
		}*/
	}
	public override bool Death(){return true;}
	public override void ComboSuccess(){}
	public override void OnColliderEnter(){}
	public override void EnergyBar_Fill(){}
	public override void EnergyBar_Decrease(){}
	//void SetAttack(Attack attack){}
	public override bool Target(){return true;}
	public override void Attack(){}
}
